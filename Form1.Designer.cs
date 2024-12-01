using System.Windows.Forms;

namespace DemoListview
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button editButton;
        private System.Windows.Forms.Button removeButton;
        private System.Windows.Forms.Label labelSTT;
        private System.Windows.Forms.Label labelID;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.TextBox textBoxSTT;
        private System.Windows.Forms.TextBox textBoxID;
        private System.Windows.Forms.TextBox textBoxName;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.listView1 = new System.Windows.Forms.ListView();
            this.addButton = new System.Windows.Forms.Button();
            this.editButton = new System.Windows.Forms.Button();
            this.removeButton = new System.Windows.Forms.Button();
            this.labelSTT = new System.Windows.Forms.Label();
            this.labelID = new System.Windows.Forms.Label();
            this.labelName = new System.Windows.Forms.Label();
            this.textBoxSTT = new System.Windows.Forms.TextBox();
            this.textBoxID = new System.Windows.Forms.TextBox();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();

            // listView1
            this.listView1.Location = new System.Drawing.Point(12, 12);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(360, 200);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = View.Details;
            this.listView1.CheckBoxes = true;
            this.listView1.Columns.Add("STT", 50, HorizontalAlignment.Left);
            this.listView1.Columns.Add("ID", 100, HorizontalAlignment.Left);
            this.listView1.Columns.Add("Name", 200, HorizontalAlignment.Left);

            // labelSTT
            this.labelSTT.AutoSize = true;
            this.labelSTT.Location = new System.Drawing.Point(12, 220);
            this.labelSTT.Name = "labelSTT";
            this.labelSTT.Size = new System.Drawing.Size(26, 13);
            this.labelSTT.TabIndex = 4;
            this.labelSTT.Text = "STT";

            // textBoxSTT
            this.textBoxSTT.Location = new System.Drawing.Point(44, 217);
            this.textBoxSTT.Name = "textBoxSTT";
            this.textBoxSTT.Size = new System.Drawing.Size(100, 20);
            this.textBoxSTT.TabIndex = 5;

            // labelID
            this.labelID.AutoSize = true;
            this.labelID.Location = new System.Drawing.Point(12, 250);
            this.labelID.Name = "labelID";
            this.labelID.Size = new System.Drawing.Size(18, 13);
            this.labelID.TabIndex = 6;
            this.labelID.Text = "ID";

            // textBoxID
            this.textBoxID.Location = new System.Drawing.Point(44, 247);
            this.textBoxID.Name = "textBoxID";
            this.textBoxID.Size = new System.Drawing.Size(100, 20);
            this.textBoxID.TabIndex = 7;

            // labelName
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(12, 280);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(35, 13);
            this.labelName.TabIndex = 8;
            this.labelName.Text = "Name";

            // textBoxName
            this.textBoxName.Location = new System.Drawing.Point(44, 277);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(100, 20);
            this.textBoxName.TabIndex = 9;

            // addButton
            this.addButton.Location = new System.Drawing.Point(297, 217);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(75, 23);
            this.addButton.TabIndex = 10;
            this.addButton.Text = "Add";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);

            // editButton
            this.editButton.Location = new System.Drawing.Point(297, 247);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(75, 23);
            this.editButton.TabIndex = 11;
            this.editButton.Text = "Edit";
            this.editButton.UseVisualStyleBackColor = true;
            this.editButton.Click += new System.EventHandler(this.editButton_Click);

            // removeButton
            this.removeButton.Location = new System.Drawing.Point(297, 277);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(75, 23);
            this.removeButton.TabIndex = 12;
            this.removeButton.Text = "Remove";
            this.removeButton.UseVisualStyleBackColor = true;
            this.removeButton.Click += new System.EventHandler(this.removeButton_Click);

            // Form1
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 311);
            this.Controls.Add(this.removeButton);
            this.Controls.Add(this.editButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.textBoxID);
            this.Controls.Add(this.labelID);
            this.Controls.Add(this.textBoxSTT);
            this.Controls.Add(this.labelSTT);
            this.Controls.Add(this.listView1);
            this.Name = "Form1";
            this.Text = "Employee Manager";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
