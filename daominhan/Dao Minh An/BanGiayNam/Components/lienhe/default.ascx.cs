using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BanGiayNam.Models;

namespace BanGiayNam.Component.lienhe
{
    public partial class _default : System.Web.UI.UserControl
    {
        DBBanGiayNam db = new DBBanGiayNam();
        Contact contact = new Contact();
        protected void Page_Load(object sender, EventArgs e)
        {
               
        }
        protected void btGui_Click(object sender, EventArgs e)
        {
            try
            {
                contact.FullName = txtFullname.Text.Trim();
                contact.Email = txtEmail.Text.Trim();
                contact.Phone = txtPhone.Text.Trim();
                contact.Title = txtTitle.Text.Trim();
                contact.Detail = txtDetail.Text.Trim();
                contact.Created_at = DateTime.Now;
                contact.Updated_by = 0;
                contact.Updated_at = DateTime.Now;
                contact.StateId = 1;
                db.Contacts.Add(contact);
                db.SaveChanges();
                txtFullname.Text = "";
                txtEmail.Text = "";
                txtPhone.Text = "";
                txtTitle.Text = "";
                txtDetail.Text = "";
                ltThongbao.Text = "<div class='alert alert-success'>Cảm ơn bạn đã liên hệ,chúng tôi sẽ cố gắng phản hồi sớm nhất có thể!!!</div>";
            }
            catch
            {
                ltThongbao.Text = "<div class='alert alert-danger'>Liên hệ thất bại!!!</div>";
            }
        }
    }
}