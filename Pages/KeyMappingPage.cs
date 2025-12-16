using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
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
        private bool _winKeyDown;

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
            InitializeMappingToggle();
        }

        private void InitializeGrid()
        {
            _bindings = new BindingList<KeyMappingRule>();
            gridControl1.DataSource = _bindings;
            gridView1.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            gridView1.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            gridView1.OptionsBehavior.Editable = true;
            gridView1.OptionsView.ShowGroupPanel = false;
            gridView1.ShownEditor += GridView1_ShownEditor;
            gridView1.HiddenEditor += GridView1_HiddenEditor;
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

        private void toggleEnableMapping_Toggled(object sender, EventArgs e)
        {
            if (_handler == null) return;

            bool enabled = toggleEnableMapping.IsOn;
            _handler.EnableKeyMapping = enabled;
            ToggleEnabledState(enabled);
            _mainForm?.PersistSettings();
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

        private void InitializeMappingToggle()
        {
            bool hasHandler = _handler != null;
            toggleEnableMapping.Enabled = hasHandler;
            bool enabled = hasHandler && _handler.EnableKeyMapping;
            toggleEnableMapping.IsOn = enabled;
            ToggleEnabledState(enabled);
        }

        private void GridView1_ShownEditor(object sender, EventArgs e)
        {
            _winKeyDown = false;
            if (gridView1.ActiveEditor is BaseEdit editor)
            {
                editor.KeyDown += Editor_KeyDown;
                editor.KeyUp += Editor_KeyUp;
            }
        }

        private void GridView1_HiddenEditor(object sender, EventArgs e)
        {
            if (gridView1.ActiveEditor is BaseEdit editor)
            {
                editor.KeyDown -= Editor_KeyDown;
                editor.KeyUp -= Editor_KeyUp;
            }

            _winKeyDown = false;
        }

        private void Editor_KeyDown(object sender, KeyEventArgs e)
        {
            UpdateWinState(e.KeyCode, true);

            if (IsModifierKey(e.KeyCode)) return;

            var stroke = CreateKeyStroke(e.KeyCode, e);
            if (stroke == null) return;

            e.Handled = true;
            e.SuppressKeyPress = true;

            gridView1.SetFocusedValue(stroke.ToDisplayString());
            gridView1.CloseEditor();
        }

        private void Editor_KeyUp(object sender, KeyEventArgs e)
        {
            UpdateWinState(e.KeyCode, false);
        }

        private KeyStroke CreateKeyStroke(Keys key, KeyEventArgs e)
        {
            if (key == Keys.None) return null;
            bool win = _winKeyDown || IsWinKey(key);
            return new KeyStroke(key, e.Control, e.Shift, e.Alt, win);
        }

        private static bool IsModifierKey(Keys key)
        {
            return key == Keys.ControlKey ||
                   key == Keys.LControlKey ||
                   key == Keys.RControlKey ||
                   key == Keys.ShiftKey ||
                   key == Keys.LShiftKey ||
                   key == Keys.RShiftKey ||
                   key == Keys.Menu ||
                   key == Keys.Alt ||
                   key == Keys.LMenu ||
                   key == Keys.RMenu ||
                   IsWinKey(key);
        }

        private static bool IsWinKey(Keys key)
        {
            return key == Keys.LWin || key == Keys.RWin;
        }

        private void UpdateWinState(Keys key, bool isDown)
        {
            if (IsWinKey(key))
            {
                _winKeyDown = isDown;
            }
        }
    }
}
