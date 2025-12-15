using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Base;
using TapCaps.Core;

namespace TapCaps.Pages
{
    public partial class KeyMappingPage : UserControl
    {
        private readonly LogicHandler _handler;
        private BindingList<KeyMappingRule> _bindings;
        private TapCaps.UI.MainForm _mainForm;

        public LogicHandler Handler => _handler;

        public KeyMappingPage(LogicHandler handler = null)
        {
            _handler = handler;
            InitializeComponent();
            this.Load += KeyMappingPage_Load;
        }

        private void KeyMappingPage_Load(object sender, EventArgs e)
        {
            _mainForm = this.FindForm() as TapCaps.UI.MainForm;
            InitializeGrid();
            LoadMappings();
            ToggleEnabledState(_handler != null);
        }

        private void InitializeGrid()
        {
            _bindings = new BindingList<KeyMappingRule>();
            gridControl1.DataSource = _bindings;
            gridView1.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            gridView1.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            gridView1.OptionsBehavior.Editable = true;
            gridView1.OptionsView.ShowGroupPanel = false;
            gridView1.CellValueChanged += GridView1_CellValueChanged;
            gridView1.ValidatingEditor += GridView1_ValidatingEditor;

            Shortcuts.FieldName = nameof(KeyMappingRule.Source);
            ShortcutActions.FieldName = nameof(KeyMappingRule.Target);
        }

        private void LoadMappings()
        {
            _bindings.Clear();
            var mappings = _handler?.GetKeyMappings() ?? new List<KeyMappingRule>();
            foreach (var map in mappings)
            {
                _bindings.Add(new KeyMappingRule { Source = map.Source, Target = map.Target });
            }
        }

        private void GridView1_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            PersistMappings();
        }

        private void GridView1_ValidatingEditor(object sender, BaseContainerValidateEditorEventArgs e)
        {
            string value = e.Value?.ToString() ?? string.Empty;
            if (string.IsNullOrWhiteSpace(value))
            {
                e.Valid = false;
                e.ErrorText = "请输入有效的快捷键，例如 Ctrl+Alt+K";
                return;
            }

            if (!KeyStroke.TryParse(value, out _))
            {
                e.Valid = false;
                e.ErrorText = "格式不正确，请使用 Ctrl+Alt+K 这样的格式";
            }
        }

        private void btnAddMapping_Click(object sender, EventArgs e)
        {
            var sample = new KeyMappingRule
            {
                Source = string.Empty,
                Target = string.Empty
            };
            _bindings.Add(sample);
            gridView1.FocusedRowHandle = gridView1.RowCount - 1;
            gridView1.FocusedColumn = Shortcuts;
            gridView1.ShowEditor();
        }

        private void btnRemoveMapping_Click(object sender, EventArgs e)
        {
            var rows = gridView1.GetSelectedRows();
            if (rows == null || rows.Length == 0) return;

            Array.Sort(rows);
            Array.Reverse(rows);
            foreach (var row in rows)
            {
                var data = gridView1.GetRow(row) as KeyMappingRule;
                if (data != null)
                {
                    _bindings.Remove(data);
                }
            }

            PersistMappings();
        }

        private void PersistMappings()
        {
            if (_handler == null) return;
            _handler.SetKeyMappings(_bindings.ToList());
            _mainForm?.PersistSettings();
        }

        private void ToggleEnabledState(bool enabled)
        {
            gridControl1.Enabled = enabled;
            btnAddMapping.Enabled = enabled;
            btnRemoveMapping.Enabled = enabled;
        }
    }
}
