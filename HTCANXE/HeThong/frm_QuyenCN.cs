using System;
using System.Windows.Forms;
using DevExpress.Utils;
using HTCANXE.Com;

namespace HTCANXE.HeThong
{
    public partial class frm_QuyenCN : DevExpress.XtraEditors.XtraForm
    {
        bool loadQCN;//--Phân biệt giữa load dữ liệu quyền chức năng Menu và Sự kiện AfterCheck
        bool flag;

        public frm_QuyenCN()
        {
            InitializeComponent();
        }

        private void frmPhanQuyen_Load(object sender, EventArgs e)
        {           
            try
            {
                using (var wait = new WaitDialogForm(Common.gCaptionNDL, Common.gTitle))
                {                    
                    loadTreeViewDSMENU(); 
                    loadDGViewDSQUYENCN();
                    if (Common.gNguoidung == "SA")
                        btnReloadMenu.Visible = true;                                      
                    wait.Close();
                }
            }
            catch (Exception ex)
            {
                ex.Message.Show(Name, MessageType.Error);
            }
        }

        private void frm_QuyenCN_KeyDown(object sender, KeyEventArgs e)
        {
            // Ctrl + H hay F1: Trợ giúp
            if ((e.Control && e.KeyCode == Keys.H) || e.KeyCode == Keys.F1)
            {
                // Code exec Help file here...
            }
            // Ctrl + N hay F6: Thêm
            if (e.Control && e.KeyCode == Keys.N || e.KeyCode == Keys.F6)
            {
                btnAdd.Focus();
                btnAdd_Click(sender, e);
            }
            // Ctrl + E hay F3: Sửa
            if (e.Control && e.KeyCode == Keys.E || e.KeyCode == Keys.F3)
            {
                btnEdit.Focus();
                btnEdit_Click(sender, e);
            }
            // Ctrl + D hay Delete: Xóa
            if ((e.Control && e.KeyCode == Keys.D) || e.KeyCode == Keys.Delete)
            {
                btnDel.Focus();
                btnDel_Click(sender, e);
            }
            // Esc: Đóng
            if (e.KeyCode == Keys.Escape)
            {
                btnClose.Focus();
                btnClose_Click(sender, e);
            }
        }

        #region LOAD DATA

        private void loadDGViewDSQUYENCN()
        {
            //gcQuyenCN.DataSource = User.GetQUYENCN();
            //key.FindKeyInGridView(0, dgvQuyenCN);
        }        

        private void loadTreeViewDSMENU()
        {
            //tvwMenu.Nodes.Clear();
            //List<TreeNode> lstRoot = new List<TreeNode>();
            //List<MENU> lstMenuCha = User.GetMenuParent();
            //foreach (MENU menu in lstMenuCha)
            //{
            //    TreeNode n = new TreeNode(menu.menuten) { Tag = menu.menuid };
            //    loadChildNode(menu.menuid, n);
            //    lstRoot.Add(n);
            //}
            //tvwMenu.Nodes.AddRange(lstRoot.ToArray());
        }

        #endregion

        #region XỬ LÝ CÁC SỰ KIỆN

        private void dgvQuyenCN_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
           // Utilities.AddOrderColumnToGridView(e);
        }

        private void dgvQuyenCN_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {           
            try
            {
                showDetails();
            }
            catch (Exception ex)
            {
                ex.Message.Show("", MessageType.Error);
            }
        }        

        private void tvwMenu_AfterCheck(object sender, TreeViewEventArgs e)
        {
            try
            {
                if (loadQCN == false)
                {
                    //Nếu là node cha được chọn => chọn tất cả node con
                    if (e.Node.Nodes.Count > 0)
                    {
                        if (flag == false)
                        {
                            bool check = e.Node.Checked;
                            setCheckedChildNode(e.Node, check);
                        }
                    }
                    //Ngược lại node con được chọn => có 2 trường hợp
                    else
                    {
                        //Trường hợp node con chọn mà node cha chưa được chọn => check node cha
                        if (e.Node.Checked && !e.Node.Parent.Checked)
                        {
                            flag = true;
                            e.Node.Parent.Checked = true;
                            flag = false;
                        }
                        //Trường hợp node con ko được chọn mà node cha được chọn => kiểm tra các node anh em của nó có thằng nào được chọn hay ko
                        //=> Nếu tất cả ko được chọn => bỏ chọn node cha luôn
                        if (!e.Node.Checked && e.Node.Parent.Checked)
                        {
                            flag = true;
                            bool result = false;
                            foreach (TreeNode node in e.Node.Parent.Nodes)
                            {
                                if (node.Checked)
                                {
                                    result = true;
                                    break;
                                }
                            }
                            if (!result)
                                e.Node.Parent.Checked = false;
                            flag = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ex.Message.Show("", MessageType.Error);
            }
        }

        private void btnReloadMenu_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    using (var wait = new WaitDialogForm(Common.gCaptionXLDL, Common.gTitle))
            //    {
            //        UpLoadMenu(new frmMain());
            //        loadTreeViewDSMENU();
            //        showDetails();
            //        wait.Close();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    ex.Message.Show("", MessageType.Error);
            //}
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    using (var frm = new frmUpdQuyenCN())
            //    {
            //        frm.ShowDialog();
            //    }
            //    if (frmUpdQuyenCN.coCapNhat)
            //    {
            //        loadDGViewDSQUYENCN(frmUpdQuyenCN.maMoi);
            //        showDetails();
            //        gcQuyenCN.Focus();
            //        frmUpdQuyenCN.coCapNhat = false;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    ex.Message.Show("", MessageType.Error);
            //}
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    if (dgvQuyenCN.RowCount > 0)
            //    {
            //        if (dgvQuyenCN.GetFocusedRowCellValue("quyenID").ToString() != "QT")
            //        {
            //            if (String.Format("Bạn có chắc là muốn xóa quyền chức năng [{0}]?", dgvQuyenCN.GetFocusedRowCellValue("quyenten")).Confirm())
            //            {
            //                string result = User.DelQUYENCN(dgvQuyenCN.GetFocusedRowCellValue("quyenID").ToString());
            //                if (String.IsNullOrEmpty(result))
            //                {
            //                    loadDGViewDSQUYENCN(String.Empty);
            //                    showDetails();
            //                    gcQuyenCN.Focus();
            //                }
            //                else
            //                {
            //                    result.Show("", MessageType.Error);
            //                }
            //            }
            //        }
            //        else
            //        {
            //            string.Format("Quyền chức năng [{0}] mặc định của hệ thống không xóa được.", dgvQuyenCN.GetFocusedRowCellValue("quyenID")).Show("", MessageType.Error);
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    ex.Message.Show(Name + "[DelQUYENCN()]", MessageType.Error);
            //}
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    if (dgvQuyenCN.RowCount > 0)
            //    {
            //        if (dgvQuyenCN.GetFocusedRowCellValue("quyenID").ToString() != "QT")
            //        {
            //            using (var wait = new WaitDialogForm(Common.gCaptionXLDL, Common.gTitle))
            //            {
            //                if (User.QuyenIdExistsInQuyenCNMenu(dgvQuyenCN.GetFocusedRowCellValue("quyenID").ToString()))
            //                {
            //                    updateQUYENCNMENU(tvwMenu.Nodes, dgvQuyenCN.GetFocusedRowCellValue("quyenID").ToString(), true);
            //                }
            //                else
            //                {
            //                    updateQUYENCNMENU(tvwMenu.Nodes, dgvQuyenCN.GetFocusedRowCellValue("quyenID").ToString(), false);
            //                }
            //                wait.Close();
            //                "Cập nhật quyền thành công.".Show("", MessageType.Information);
            //                gcQuyenCN.Focus();
            //            }
            //        }
            //        else
            //        {
            //            if (Common.gNguoidung == "SA")
            //            {
            //                using (var wait = new WaitDialogForm(Common.gCaptionXLDL, Common.gTitle))
            //                {
            //                    if (User.QuyenIdExistsInQuyenCNMenu(dgvQuyenCN.GetFocusedRowCellValue("quyenID").ToString()))
            //                    {
            //                        updateQUYENCNMENU(tvwMenu.Nodes, dgvQuyenCN.GetFocusedRowCellValue("quyenID").ToString(), true);
            //                    }
            //                    else
            //                    {
            //                        updateQUYENCNMENU(tvwMenu.Nodes, dgvQuyenCN.GetFocusedRowCellValue("quyenID").ToString(), false);
            //                    }
            //                    wait.Close();
            //                    "Cập nhật quyền thành công.".Show("", MessageType.Information);
            //                    gcQuyenCN.Focus();
            //                }
            //            }
            //            else
            //            {
            //                string.Format("Quyền chức năng [{0}] mặc định của hệ thống không sửa được.", dgvQuyenCN.GetFocusedRowCellValue("quyenID")).Show("", MessageType.Error);
            //            }
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    ex.Message.Show(Name + "[UpdateQUYENCN()]", MessageType.Error);
            //}
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        #endregion

        #region CÁC PHƯƠNG THỨC XỬ LÝ

        private void showDetails()
        {
            loadQCN = true;
            //Khởi tạo lại các quyền CN Menu rỗng
            initializeTreeViewDMMENU(tvwMenu.Nodes);
            //Checked lại các quyền CN Menu tương ứng
            loadCheckedNode();
            loadQCN = false;
        }        

        private static void initializeTreeViewDMMENU(TreeNodeCollection nodeColl)
        {
            foreach (TreeNode node in nodeColl)
            {
                node.Checked = false;
                if (node.Nodes.Count > 0)
                {
                    initializeTreeViewDMMENU(node.Nodes);
                }
            }
        }

        private void loadCheckedNode()
        {
            //List<QUYENCNMENU> lstQuyenCNMenu = User.GetQCNMenuIsActive(quyenid);
            //if (lstQuyenCNMenu.Count > 0)
            //{
            //    foreach (QUYENCNMENU quyen in lstQuyenCNMenu)
            //    {
            //        setCheckedNode(tvwMenu.Nodes, quyen.menuID);
            //    }
            //}
        }

        private static void setCheckedChildNode(TreeNode parentNode, bool value)
        {
            for (int i = 0; i < parentNode.Nodes.Count; i++)
            {
                parentNode.Nodes[i].Checked = value;
            }
        }

        #endregion                                              

      
    }
}