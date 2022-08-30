namespace Colloquio
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.labelAmbulatori = new System.Windows.Forms.TextBox();
            this.labelPartiDelCorpo = new System.Windows.Forms.TextBox();
            this.labelEsami = new System.Windows.Forms.TextBox();
            this.buttonCerca = new System.Windows.Forms.Button();
            this.textBoxScriviQui = new System.Windows.Forms.TextBox();
            this.comboBoxRicerca = new System.Windows.Forms.ComboBox();
            this.labelRicerca = new System.Windows.Forms.TextBox();
            this.listBoxAmbulatori = new System.Windows.Forms.ListBox();
            this.dbColloquioDataSet = new Colloquio.dbColloquioDataSet();
            this.listBoxPartiCorpo = new System.Windows.Forms.ListBox();
            this.buttonAggiungi = new System.Windows.Forms.Button();
            this.labelEsamiAggiunti = new System.Windows.Forms.TextBox();
            this.dbColloquioDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.listViewEsamiAggiunti = new System.Windows.Forms.ListView();
            this.listViewEsami = new System.Windows.Forms.ListView();
            this.buttonRemove = new System.Windows.Forms.Button();
            this.buttonVediTutto = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dbColloquioDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbColloquioDataSetBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // labelAmbulatori
            // 
            this.labelAmbulatori.BackColor = System.Drawing.SystemColors.Control;
            this.labelAmbulatori.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.labelAmbulatori.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAmbulatori.Location = new System.Drawing.Point(13, 72);
            this.labelAmbulatori.Name = "labelAmbulatori";
            this.labelAmbulatori.Size = new System.Drawing.Size(70, 13);
            this.labelAmbulatori.TabIndex = 2;
            this.labelAmbulatori.Text = "Ambulatori";
            // 
            // labelPartiDelCorpo
            // 
            this.labelPartiDelCorpo.BackColor = System.Drawing.SystemColors.Control;
            this.labelPartiDelCorpo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.labelPartiDelCorpo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPartiDelCorpo.Location = new System.Drawing.Point(192, 72);
            this.labelPartiDelCorpo.Name = "labelPartiDelCorpo";
            this.labelPartiDelCorpo.Size = new System.Drawing.Size(90, 13);
            this.labelPartiDelCorpo.TabIndex = 3;
            this.labelPartiDelCorpo.Text = "Parti del corpo";
            // 
            // labelEsami
            // 
            this.labelEsami.BackColor = System.Drawing.SystemColors.Control;
            this.labelEsami.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.labelEsami.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEsami.Location = new System.Drawing.Point(341, 72);
            this.labelEsami.Name = "labelEsami";
            this.labelEsami.Size = new System.Drawing.Size(70, 13);
            this.labelEsami.TabIndex = 4;
            this.labelEsami.Text = "Esami";
            // 
            // buttonCerca
            // 
            this.buttonCerca.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonCerca.Location = new System.Drawing.Point(245, 29);
            this.buttonCerca.Name = "buttonCerca";
            this.buttonCerca.Size = new System.Drawing.Size(70, 23);
            this.buttonCerca.TabIndex = 2;
            this.buttonCerca.Text = "Cerca";
            this.buttonCerca.UseVisualStyleBackColor = true;
            this.buttonCerca.Click += new System.EventHandler(this.ButtonCerca_Click);
            // 
            // textBoxScriviQui
            // 
            this.textBoxScriviQui.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxScriviQui.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.textBoxScriviQui.Location = new System.Drawing.Point(139, 31);
            this.textBoxScriviQui.Name = "textBoxScriviQui";
            this.textBoxScriviQui.Size = new System.Drawing.Size(100, 20);
            this.textBoxScriviQui.TabIndex = 1;
            this.textBoxScriviQui.Text = "Scrivi qui";
            this.textBoxScriviQui.Click += new System.EventHandler(this.TextBoxScriviQui_Click);
            this.textBoxScriviQui.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxScriviQui_KeyDown);
            // 
            // comboBoxRicerca
            // 
            this.comboBoxRicerca.Cursor = System.Windows.Forms.Cursors.Hand;
            this.comboBoxRicerca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxRicerca.FormattingEnabled = true;
            this.comboBoxRicerca.Items.AddRange(new object[] {
            "Nome Esame",
            "Codice Ministeriale",
            "Codice Interno",
            "Descrizione Esame",
            "Tutto"});
            this.comboBoxRicerca.Location = new System.Drawing.Point(12, 31);
            this.comboBoxRicerca.Name = "comboBoxRicerca";
            this.comboBoxRicerca.Size = new System.Drawing.Size(121, 21);
            this.comboBoxRicerca.TabIndex = 0;
            // 
            // labelRicerca
            // 
            this.labelRicerca.BackColor = System.Drawing.SystemColors.Control;
            this.labelRicerca.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.labelRicerca.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRicerca.Location = new System.Drawing.Point(12, 12);
            this.labelRicerca.Name = "labelRicerca";
            this.labelRicerca.Size = new System.Drawing.Size(70, 13);
            this.labelRicerca.TabIndex = 6;
            this.labelRicerca.Text = "Ricerca";
            // 
            // listBoxAmbulatori
            // 
            this.listBoxAmbulatori.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listBoxAmbulatori.FormattingEnabled = true;
            this.listBoxAmbulatori.Location = new System.Drawing.Point(13, 91);
            this.listBoxAmbulatori.Name = "listBoxAmbulatori";
            this.listBoxAmbulatori.Size = new System.Drawing.Size(150, 171);
            this.listBoxAmbulatori.Sorted = true;
            this.listBoxAmbulatori.TabIndex = 8;
            // 
            // dbColloquioDataSet
            // 
            this.dbColloquioDataSet.DataSetName = "dbColloquioDataSet";
            this.dbColloquioDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // listBoxPartiCorpo
            // 
            this.listBoxPartiCorpo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listBoxPartiCorpo.FormattingEnabled = true;
            this.listBoxPartiCorpo.Location = new System.Drawing.Point(192, 91);
            this.listBoxPartiCorpo.Name = "listBoxPartiCorpo";
            this.listBoxPartiCorpo.Size = new System.Drawing.Size(123, 171);
            this.listBoxPartiCorpo.Sorted = true;
            this.listBoxPartiCorpo.TabIndex = 9;
            this.listBoxPartiCorpo.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ListBoxPartiCorpo_MouseClick);
            // 
            // buttonAggiungi
            // 
            this.buttonAggiungi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonAggiungi.Location = new System.Drawing.Point(675, 167);
            this.buttonAggiungi.Name = "buttonAggiungi";
            this.buttonAggiungi.Size = new System.Drawing.Size(75, 23);
            this.buttonAggiungi.TabIndex = 11;
            this.buttonAggiungi.Text = "Aggiungi";
            this.buttonAggiungi.UseVisualStyleBackColor = true;
            this.buttonAggiungi.Click += new System.EventHandler(this.ButtonAggiungi_Click);
            // 
            // labelEsamiAggiunti
            // 
            this.labelEsamiAggiunti.BackColor = System.Drawing.SystemColors.Control;
            this.labelEsamiAggiunti.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.labelEsamiAggiunti.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEsamiAggiunti.Location = new System.Drawing.Point(341, 277);
            this.labelEsamiAggiunti.Name = "labelEsamiAggiunti";
            this.labelEsamiAggiunti.Size = new System.Drawing.Size(90, 13);
            this.labelEsamiAggiunti.TabIndex = 12;
            this.labelEsamiAggiunti.Text = "Esami Aggiunti";
            // 
            // dbColloquioDataSetBindingSource
            // 
            this.dbColloquioDataSetBindingSource.DataSource = this.dbColloquioDataSet;
            this.dbColloquioDataSetBindingSource.Position = 0;
            // 
            // listViewEsamiAggiunti
            // 
            this.listViewEsamiAggiunti.HideSelection = false;
            this.listViewEsamiAggiunti.Location = new System.Drawing.Point(341, 296);
            this.listViewEsamiAggiunti.Name = "listViewEsamiAggiunti";
            this.listViewEsamiAggiunti.Size = new System.Drawing.Size(328, 119);
            this.listViewEsamiAggiunti.TabIndex = 16;
            this.listViewEsamiAggiunti.UseCompatibleStateImageBehavior = false;
            // 
            // listViewEsami
            // 
            this.listViewEsami.HideSelection = false;
            this.listViewEsami.Location = new System.Drawing.Point(341, 91);
            this.listViewEsami.Name = "listViewEsami";
            this.listViewEsami.Size = new System.Drawing.Size(328, 171);
            this.listViewEsami.TabIndex = 18;
            this.listViewEsami.UseCompatibleStateImageBehavior = false;
            // 
            // buttonRemove
            // 
            this.buttonRemove.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonRemove.Location = new System.Drawing.Point(675, 343);
            this.buttonRemove.Name = "buttonRemove";
            this.buttonRemove.Size = new System.Drawing.Size(75, 23);
            this.buttonRemove.TabIndex = 19;
            this.buttonRemove.Text = "Rimuovi";
            this.buttonRemove.UseVisualStyleBackColor = true;
            this.buttonRemove.Click += new System.EventHandler(this.ButtonRemove_Click);
            // 
            // buttonVediTutto
            // 
            this.buttonVediTutto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonVediTutto.Location = new System.Drawing.Point(594, 62);
            this.buttonVediTutto.Name = "buttonVediTutto";
            this.buttonVediTutto.Size = new System.Drawing.Size(75, 23);
            this.buttonVediTutto.TabIndex = 20;
            this.buttonVediTutto.Text = "Vedi Tutto";
            this.buttonVediTutto.UseVisualStyleBackColor = true;
            this.buttonVediTutto.Click += new System.EventHandler(this.ButtonVediTutto_Click);
            // 
            // button2
            // 
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.Location = new System.Drawing.Point(675, 392);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(104, 23);
            this.button2.TabIndex = 22;
            this.button2.Text = "Conferma Stampa";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(852, 450);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.buttonVediTutto);
            this.Controls.Add(this.buttonRemove);
            this.Controls.Add(this.listViewEsami);
            this.Controls.Add(this.listViewEsamiAggiunti);
            this.Controls.Add(this.labelEsamiAggiunti);
            this.Controls.Add(this.buttonAggiungi);
            this.Controls.Add(this.listBoxPartiCorpo);
            this.Controls.Add(this.listBoxAmbulatori);
            this.Controls.Add(this.buttonCerca);
            this.Controls.Add(this.labelRicerca);
            this.Controls.Add(this.textBoxScriviQui);
            this.Controls.Add(this.comboBoxRicerca);
            this.Controls.Add(this.labelEsami);
            this.Controls.Add(this.labelPartiDelCorpo);
            this.Controls.Add(this.labelAmbulatori);
            this.Name = "Form1";
            this.Text = "Colloquio";
            this.Load += new System.EventHandler(this.OnLoadData);
            ((System.ComponentModel.ISupportInitialize)(this.dbColloquioDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbColloquioDataSetBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox labelAmbulatori;
        private System.Windows.Forms.TextBox labelPartiDelCorpo;
        private System.Windows.Forms.TextBox labelEsami;
        private System.Windows.Forms.TextBox labelRicerca;
        private System.Windows.Forms.ComboBox comboBoxRicerca;
        private System.Windows.Forms.Button buttonCerca;
        private System.Windows.Forms.TextBox textBoxScriviQui;
        private System.Windows.Forms.ListBox listBoxAmbulatori;
        private System.Windows.Forms.ListBox listBoxPartiCorpo;
        private System.Windows.Forms.Button buttonAggiungi;
        private System.Windows.Forms.TextBox labelEsamiAggiunti;
        private System.Windows.Forms.BindingSource dbColloquioDataSetBindingSource;
        private dbColloquioDataSet dbColloquioDataSet;
        private System.Windows.Forms.ListView listViewEsamiAggiunti;
        private System.Windows.Forms.ListView listViewEsami;
        private System.Windows.Forms.Button buttonRemove;
        private System.Windows.Forms.Button buttonVediTutto;
        private System.Windows.Forms.Button button2;
    }
}

