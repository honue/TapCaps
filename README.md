
<p align="center">
  <img src="TapCaps.png" alt="logo" width="120" />
   <h1 align="center">TapCaps</h1>
</p>

<p align="center">
  <a href="https://github.com/honue/TapCaps/stargazers"><img src="https://img.shields.io/github/stars/honue/TapCaps?style=for-the-badge" alt="GitHub Repo stars"></a>
  <a href="https://github.com/honue/TapCaps/releases"><img src="https://img.shields.io/github/downloads/honue/TapCaps/total?style=for-the-badge" alt="GitHub downloads"></a>
  <img src="https://img.shields.io/badge/platform-Windows-blue?style=for-the-badge" alt="Platform Windows">
  <img src="https://img.shields.io/badge/.NET-4.7.2-blueviolet?style=for-the-badge" alt=".NET 4.7.2">
</p>

## 功能
- macOS 风格 CapsLock：短按切换中/英文，长按锁定大写，阈值可调。
- HUD 提示：在光标附近显示 中/英 或 CapsLock 状态。
- 按键映射：把组合键映射到另一组快捷键并拦截原按键。
- 托盘驻留：最小化到托盘，双击恢复，可选开机自启。

## 使用方式
1. 运行 `TapCaps.exe`，程序会注册键盘钩子并驻留托盘，需要时再打开界面。
2. 「快速设置」可开关 macOS 风格 CapsLock、HUD、托盘图标，并调整长按阈值。
3. 「按键映射」可添加/删除规则：在表格填写源快捷键和目标快捷键（如 `Ctrl+Shift+J -> Ctrl+Alt+J`），保存即生效。
4. 退出：托盘菜单选择“退出”或主界面关闭并确认。

## 兼容性与注意事项
- 测试环境：Windows 11 + 微软拼音。
- 如遇权限拦截，可尝试管理员运行。
- HUD 未出现时，切换窗口或重启程序再试。
