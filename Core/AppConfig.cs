using System;

namespace TapCaps.Core
{
    /// <summary>
    /// 应用程序配置和常量
    /// </summary>
    public static class AppConfig
    {
        /// <summary>
        /// 长按阈值（毫秒）- 超过此时间视为长按
        /// </summary>
        public const int LongPressThresholdMs = 250;

        /// <summary>
        /// 键盘钩子注入标识符
        /// </summary>
        public const uint KeyboardHookSignature = 0x12345;

        /// <summary>
        /// HUD 显示时长（毫秒）
        /// </summary>
        public const int HudDisplayDurationMs = 1500;

        /// <summary>
        /// HUD 淡出间隔（毫秒）
        /// </summary>
        public const int HudFadeIntervalMs = 10;

        /// <summary>
        /// HUD 淡出步长
        /// </summary>
        public const double HudFadeStep = 0.1;

        /// <summary>
        /// HUD 不透明度
        /// </summary>
        public const double HudOpacity = 0.9;

        /// <summary>
        /// HUD 圆角半径
        /// </summary>
        public const int HudCornerRadius = 10;

        /// <summary>
        /// HUD 背景颜色
        /// </summary>
        public const string HudBackgroundColor = "#017AFF";

        /// <summary>
        /// HUD 字体名称
        /// </summary>
        public const string HudFontName = "Microsoft YaHei";

        /// <summary>
        /// HUD 字体大小
        /// </summary>
        public const float HudFontSize = 11f;

        /// <summary>
        /// HUD 与光标的垂直偏移（像素）
        /// </summary>
        public const int HudCaretOffsetY = 5;

        /// <summary>
        /// HUD 水平内边距（像素）
        /// </summary>
        public const int HudPaddingX = 8;

        /// <summary>
        /// HUD 垂直内边距（像素）
        /// </summary>
        public const int HudPaddingY = 6;
    }
}
