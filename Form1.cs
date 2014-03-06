using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
namespace Yellow__Printer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitialTextBox();
             
        }
        Hashtable SPriceCollection = new Hashtable();//存储SingerPrice
        private bool m_nonNumberEntered = false;

        private void InitialTextBox()
        {//初始化 textBox控件
            int RCount = this.tableLayoutPanel1.RowCount;
            int CCount = this.tableLayoutPanel1.ColumnCount;

            int TabIndex=0;
            for (int i = 0; i < RCount; i++)
            {

                for (int j = 1; j < CCount; j++)
                {
                  
                    TextBox TB =(TextBox) tableLayoutPanel1.GetControlFromPosition(j, i);
                  //添加changed时间
                    TB.TextChanged += TBTextChanged; 
                    if (j <= 5)//前5个
                    {
                        TB.TabIndex = TabIndex++;
                        
                    }
                    else 
                    {
                        TB.TabIndex=100;
                    
                    
                    }

                    TB.Text = "";
                    switch(j)
                    {
                        case 1: TB.Name = "Specification_"+i; break;
                        case 2: TB.Name = "Color_" + i; break;
                        case 3: TB.Name = "Unit_" + i; break;
                        case 4: TB.Name = "Mount_" + i; TB.KeyDown += this.TBKeyDown1; TB.KeyPress += this.TBKeyPress; TB.LostFocus += tBLeave; break;
                        case 5: TB.Name = "SinglePrice_" + i; TB.KeyDown += this.TBKeyDown; TB.KeyPress += this.TBKeyPress; TB.LostFocus += tBLeave; break;
                        case 6: TB.Name = "S0_" + i; break;
                        case 7: TB.Name = "S1_" + i; break;
                        case 8: TB.Name = "S2_" + i; break;
                        case 9: TB.Name = "S3_" + i; break;
                        case 10: TB.Name = "S4_" + i; break;
                        case 11: TB.Name = "S5_" + i; break;
                        case 12: TB.Name = "S6_" + i; break;
                        case 13: TB.Name = "Remark_" + i; break;
                        default: TB.Name = "Other_" + i; break;
                     }
                
                }
            
            
            
            }
  
         
        
        
        }
        private void TBKeyDown(object sender, KeyEventArgs e)//价格
        {
            // Initialize the flag to false.
            m_nonNumberEntered = false;
           
         
            // Determine whether the keystroke is a number from the top of the keyboard.
            if (e.KeyCode < Keys.D0 || e.KeyCode > Keys.D9)
            {
                // Determine whether the keystroke is a number from the keypad.
                if (e.KeyCode < Keys.NumPad0 || e.KeyCode > Keys.NumPad9)
                {
                    // Determine whether the keystroke is a backspace.
                    if (e.KeyCode != Keys.Back)
                    {
                        // A non-numerical keystroke was pressed.
                        // Set the flag to true and evaluate in KeyPress event.
                        m_nonNumberEntered = true;
                    }
                }
            }
            if (e.KeyCode == Keys.Decimal)
            {
                m_nonNumberEntered = false;
            
            }

        }
        private void TBKeyDown1(object sender, KeyEventArgs e)
        {
            // Initialize the flag to false.
            m_nonNumberEntered = false;
           
         
            // Determine whether the keystroke is a number from the top of the keyboard.
            if (e.KeyCode < Keys.D0 || e.KeyCode > Keys.D9)
            {
                // Determine whether the keystroke is a number from the keypad.
                if (e.KeyCode < Keys.NumPad0 || e.KeyCode > Keys.NumPad9)
                {
                    // Determine whether the keystroke is a backspace.
                    if (e.KeyCode != Keys.Back)
                    {
                        // A non-numerical keystroke was pressed.
                        // Set the flag to true and evaluate in KeyPress event.
                        m_nonNumberEntered = true;
                    }
                }
            }
        

        }//数量
        private void TBTextChanged(object sender, EventArgs e)
        {
            TextBox TxtBox = (TextBox)sender;
            this.toolTip.SetToolTip(TxtBox, TxtBox.Text);
        
        }




        private void TBKeyPress(object sender, KeyPressEventArgs e)
        {
            // Check for the flag being set in the KeyDown event.
            if (m_nonNumberEntered)
            {
                // Stop the character from being entered into the control
                // since it is non-numerical.
                e.Handled = true;
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            int RCount = this.tableLayoutPanel1.RowCount-1;
            int CCount = this.tableLayoutPanel1.ColumnCount;

        
        

            DataSet1 DS = new DataSet1();
            DataTable Dt = DS.DataTable1;
            for (int i = 0; i < RCount; i++)
            {


              //  TextBox TB = ;

                DataRow dr = Dt.NewRow();
                dr["Index"] = i+1;
                dr["Specification"] = ((TextBox)tableLayoutPanel1.GetControlFromPosition(1, i)).Text.Trim();
                dr["Color"] = ((TextBox)tableLayoutPanel1.GetControlFromPosition(2, i)).Text.Trim();
                dr["Unit"] = ((TextBox)tableLayoutPanel1.GetControlFromPosition(3, i)).Text.Trim();
                dr["Amount"] = ((TextBox)tableLayoutPanel1.GetControlFromPosition(4, i)).Text.Trim();
                dr["SinglePrice"] = ((TextBox)tableLayoutPanel1.GetControlFromPosition(5, i)).Text.Trim();



                dr["S0"] = ((TextBox)tableLayoutPanel1.GetControlFromPosition(6, i)).Text.Trim();
                dr["S1"] = ((TextBox)tableLayoutPanel1.GetControlFromPosition(7, i)).Text.Trim();
                dr["S2"] = ((TextBox)tableLayoutPanel1.GetControlFromPosition(8, i)).Text.Trim();
                dr["S3"] = ((TextBox)tableLayoutPanel1.GetControlFromPosition(9, i)).Text.Trim();
                dr["S4"] = ((TextBox)tableLayoutPanel1.GetControlFromPosition(10, i)).Text.Trim();
                dr["S5"] = ((TextBox)tableLayoutPanel1.GetControlFromPosition(11, i)).Text.Trim();
                dr["S6"] = ((TextBox)tableLayoutPanel1.GetControlFromPosition(12, i)).Text.Trim();
                dr["Remark"] = ((TextBox)tableLayoutPanel1.GetControlFromPosition(13, i)).Text.Trim();

                dr["Price"] ="";
                dr["TotalPrice"] = this.TotalPrice.Text;
                dr["CustomerName"] = this.CustomerName.Text;
                dr["NO"] = this.NO.Text;
                dr["Creator"] = this.Creator.Text;
                dr["Buyer"] = this.Buyer.Text;
                dr["Year"] = this.Year.Text;
                dr["Month"] = this.Month.Text;
                dr["Day"] = this.Day.Text;
                dr["CHTotalPrice"] = this.TxtTotalPrice.Text;
                Dt.Rows.Add(dr);

            }
            //测试
            //DataTable newDt = Dt;
            //newDt.TableName = "NewTable1";
            //DS.Tables.Add(newDt);
            Reports ReportDialog = new Reports(DS);
            ReportDialog.WindowState = FormWindowState.Maximized; 
            ReportDialog.ShowDialog(); 
            
        }
        
        /// <summary>
        /// 计算并显示总花费
        /// </summary>
        private void CaculateTotalPrice()
        {
            Double SumaryPrice=0;
            IEnumerator IE = SPriceCollection.GetEnumerator();
            while (IE.MoveNext())
            { 
               if(IE.Current.ToString() !="")
               {



                   SumaryPrice += Double.Parse(((System.Collections.DictionaryEntry)(IE.Current)).Value.ToString()); 
               
               
               }
            
            }
            this.TotalPrice.Text = SumaryPrice.ToString();
            // 显示对应大写字符
          
        
        }


          private string GetNumber(string oo)
          {
              string Money = "";
              try
              {

                  string[] Number1 ={ "零", "壹", "贰", "叁", "肆", "伍", "陆", "柒", "捌", "玖", "拾" };
                  string[] Number2 ={ "元", "拾", "佰", "仟", "万", "十万", "百万", "千万", "亿", "十亿", "百亿", "千亿", "兆", "十兆", "百兆", "千兆" };
              
                  if (oo.IndexOf(".") == -1)
                  {
                      int i = 0;
                      for (i = oo.Length; i > 0; i--)
                      {
                          string dd = Number1[Convert.ToInt32(oo.Substring(i - 1, 1))];
                          if (oo.Substring(i - 1, 1) != "0")
                          {
                              if (Number2[oo.Length - i].Length > 1)
                              {
                                  dd += " " + Number2[(oo.Length - i) % 4] + " ";
                              }
                              else
                                  dd += " " + Number2[oo.Length - i] + " ";
                              Money = dd + Money;
                          }
                          else
                          {

                              if (Number2[oo.Length - i].Length > 1)
                              {
                                  Money = "零 " + Number2[(oo.Length - i) % 4] + " " + Money;
                              }
                              else
                                  Money = "零 " + Number2[oo.Length - i] + " "+Money;
                          
                          }
                         
                             
                           
                           
                      }

                      while (Money.EndsWith("零"))
                      {
                         Money=Money.Substring(0,Money.LastIndexOf("零")-1);
                      
                      }
                      Money += "零 角";
                  }
                  else
                  {
                      int dd = oo.IndexOf(".");
                      string Intstr = oo.Substring(0, dd++);

                      string Distr = oo.Substring(dd, 1);
                      int i = 0;
                      for (i = Intstr.Length; i > 0; i--)
                      {
                          string dd1 = Number1[Convert.ToInt32(Intstr.Substring(i - 1, 1))];
                          if (oo.Substring(i - 1, 1) != "0")
                          {
                              if (Number2[Intstr.Length - i].Length > 1)
                              {
                                  dd1 += " " + Number2[(Intstr.Length - i) % 4] + " ";
                              }
                              else
                                  dd1 += " " + Number2[Intstr.Length - i] + " ";
                              Money = dd1 + Money;
                          }
                        

                        else
                          {

                              if (Number2[Intstr.Length - i].Length > 1)
                              {
                                  Money = "零 " + Number2[(Intstr.Length - i) % 4] + " " + Money;
                              }
                              else
                                  Money = "零 " + Number2[Intstr.Length - i] + " " + Money;
                          
                          }
                         
                      }

                   

                      //Money+="点";
                      //for(i=0;i<Distr.Length;i++)
                      //{
                      // Money+=(Number1[Convert.ToInt32(Distr.Substring(i,1))]);
                      //}


                        while (Money.EndsWith("零"))
                      {
                         Money=Money.Substring(0,Money.LastIndexOf("零")-1);
                      
                      }
                     
                      Money += (Number1[Convert.ToInt32(Distr.Substring(0, 1))]);
                      Money += " 角";
                   
                  }
              }
              catch (OverflowException Ex)
              { return Money; }
              catch (Exception Ex1)
              { return Money; }
              return Money;    
            }
               
 



        private void tBLeave(object sender, EventArgs e)
        {
            // MessageBox.Show(((TextBox)sender).Text + ((TextBox)sender).Name ); 
            TextBox TB = (TextBox)sender;
            TableLayoutPanelCellPosition Position = this.tableLayoutPanel1.GetCellPosition(TB);

            //int RCount = this.tableLayoutPanel1.RowCount;
            int CCount = this.tableLayoutPanel1.ColumnCount;
            Int64 Amount;
            Double SPrice;
            TextBox AmountText = (TextBox)tableLayoutPanel1.GetControlFromPosition(4, Position.Row);
            TextBox SPriceText = (TextBox)tableLayoutPanel1.GetControlFromPosition(5, Position.Row);
            if (AmountText.Text.Trim() != "")
            {
                Amount = Int64.Parse(AmountText.Text.Trim());
            }
            else
            {
                Amount = 0;
            }

            SPrice = SPriceText.Text.Trim() == "" ? 0 : Double.Parse(SPriceText.Text.Trim());
            Double SinglePrice= SPrice * Amount;
            // 添加SingerPrice 集合 并计算

            if (!SPriceCollection.Contains(Position.Row))
            {
                SPriceCollection.Add(Position.Row, SinglePrice);
               
            }
            else
            {
                SPriceCollection[Position.Row] = SinglePrice;
            
            }
            CaculateTotalPrice();
            //
            string[] strArray = SinglePrice.ToString().Split('.');

            string str = strArray[0].ToString();//Money字符串
            int Count = str.Length;
            int var_i = 1;

            TextBox txB;
            string TempStr=string.Empty;
            for (int j = 11; j > 5; j--)//6-12
            {
                txB= (TextBox)tableLayoutPanel1.GetControlFromPosition(j, Position.Row);


                if (SPrice == 0 || Amount == 0) TempStr = "";
                else
                {
                    if (j != 6)
                    {
                        if (Count - var_i >= 0)
                        {
                            TempStr = str[Count - var_i].ToString();
                            var_i++;
                        }
                        else
                        {
                            TempStr = "";
                        }
                    }
                    else
                    {
                        if (Count - var_i >= 0)
                        {
                            TempStr = str.Substring(0,Count - var_i+1).ToString();
                            var_i++;
                        }
                        else
                        {
                            TempStr = "";
                        }
                    
                    
                    }

                    



                }
                txB.Text = TempStr;
                

            }
            //


            //

            //角
            if (strArray.Length == 2)
            {
                  txB = (TextBox)tableLayoutPanel1.GetControlFromPosition(12, Position.Row);
                  txB.Text =strArray[1].ToString().Substring(0,1) ;
                  if (txB.Text.Trim() == "0")
                  {
                      txB.Text = "";
                  
                  }
            }
        }

        private void TotalPrice_TextChanged(object sender, EventArgs e)
        {
            this.TxtTotalPrice.Text = GetNumber(this.TotalPrice.Text.ToString());
        }

        private void Creator_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {    
            foreach (Control cl in this.Controls)
            {
                if (cl.GetType().ToString() == "System.Windows.Forms.TextBox") 
             {
                 ((TextBox)(cl)).Text = "";
             
             }
            
            
            }

            foreach (Control cl in this.tableLayoutPanel1.Controls)
            {
                if (cl.GetType().ToString() == "System.Windows.Forms.TextBox")
                {
                    ((TextBox)(cl)).Text = "";

                }


            }

        }

        private void Form1_Click(object sender, EventArgs e)
        {
            this.CustomerName.Select(); 
        }
       
        
    }
}