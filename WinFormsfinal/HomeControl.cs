using System;
using System.Windows.Forms;

namespace WinFormsfinal
{
    public partial class HomeControl : UserControl
    {
        public HomeControl()
        {
            InitializeComponent();

            // Căn lại vị trí ban đầu khi control được tạo
            CenterBanner();
            CenterCards();
        }

        // ==== EVENT HANDLER cho Resize (Designer đang gọi) ====

        private void bannerBackground_Resize(object sender, EventArgs e)
        {
            CenterBanner();
        }

        private void areaPanel_Resize(object sender, EventArgs e)
        {
            CenterCards();
        }

        // ==== HÀM PHỤ ĐỂ CĂN GIỮA ====

        private void CenterBanner()
        {
            // căn giữa bannerInner trong bannerBackground
            bannerInner.Left = (bannerBackground.ClientSize.Width - bannerInner.Width) / 2;
            bannerInner.Top  = (bannerBackground.ClientSize.Height - bannerInner.Height) / 2;

            // mũi tên trái/phải nằm giữa chiều cao, mũi tên phải sát mép phải
            lblArrowLeft.Top  = (bannerBackground.Height - lblArrowLeft.Height) / 2;
            lblArrowRight.Top = (bannerBackground.Height - lblArrowRight.Height) / 2;
            lblArrowRight.Left = bannerBackground.Width - lblArrowRight.Width - 10;
        }

        private void CenterCards()
        {
            // căn giữa 3 card và đường kẻ
            cardsHost.Left = (areaPanel.ClientSize.Width - cardsHost.Width) / 2;
            line.Left      = (areaPanel.ClientSize.Width - line.Width) / 2;
        }
    }
}
