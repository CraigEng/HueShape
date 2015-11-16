using System.Windows.Forms;

namespace HueShape.CustomControls
{
    public partial class DoubleBufferPanel : Panel
    {
        public DoubleBufferPanel()
        {
            InitializeComponent();

            SetStyle(
                     ControlStyles.UserPaint |
                     ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.OptimizedDoubleBuffer, true);
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }
    }
}