using MVCPage.ViewModel;

namespace MVCPage.Interfaces {
    public interface IThuocServiceView {
        ThuocIndexVM GetThuocIndexVM (string searchString, int pageIndex = 1);
    }
}