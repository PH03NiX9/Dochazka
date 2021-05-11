using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;


namespace Dochazka
{
    class Tisk
    {
        public string Tiskni(FormHlavni oForm)
        {
            string sSouborTemplate = Path.Combine(Application.StartupPath, "tisk.htm");
            string sSouborTisk = Path.Combine(Functions.GetApplicationDataPath(), "tisk.htm");
            StringBuilder sTemplate=new StringBuilder();
            using (StreamReader srTemplate = new StreamReader(sSouborTemplate, Encoding.GetEncoding(1250)))
            {
                string sLine = "";
                while ((sLine = srTemplate.ReadLine()) != null)
                    sTemplate.Append(sLine);

            }
            StringBuilder sbPolozky = new StringBuilder();
            foreach (ListViewItem lvItem in oForm.lvDochazka.Items)
            {
                sbPolozky.AppendLine("<tr>");
                sbPolozky.AppendLine("<td>"+lvItem.Text+"</td>");
                sbPolozky.AppendLine("<td>" + lvItem.SubItems[1].Text + "</td>");
                sbPolozky.AppendLine("<td>" + lvItem.SubItems[2].Text + "</td>");
                try { sbPolozky.AppendLine("<td>" + lvItem.SubItems[3].Text + "</td>"); }
                catch { sbPolozky.AppendLine("<td></td>"); }
                sbPolozky.AppendLine("</tr>");
            }

            sTemplate.Replace("#jmenozamestnance#", Program.oUzivatele.GetSelectUser().prijmeni + " " + Program.oUzivatele.GetSelectUser().jmeno);
            sTemplate.Replace("#sumahodin#",oForm.lbSumaHodin.Text );
            sTemplate.Replace("#dovolena#", oForm.lbDovolena.Text);
            sTemplate.Replace("#nemoc#", oForm.lbNemoc.Text);
            sTemplate.Replace("#ocr#", oForm.lbOCR.Text);
            sTemplate.Replace("#lekar#", oForm.lbLekar.Text);
            sTemplate.Replace("#polozky#",sbPolozky.ToString());

            StreamWriter swPrint = new StreamWriter(sSouborTisk, false, Encoding.GetEncoding(1250));
            try
            {
                swPrint.Write(sTemplate.ToString());
            }
            catch
            { 
            
            }
            swPrint.Close();
            return sSouborTisk;


        }

    }
}

