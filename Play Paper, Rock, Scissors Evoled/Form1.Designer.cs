namespace Play_Paper__Rock__Scissors_Evoled
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.Title = new System.Windows.Forms.Label();
            this.instructions = new System.Windows.Forms.Button();
            this.labelPlayer1 = new System.Windows.Forms.Label();
            this.labelplayer2 = new System.Windows.Forms.Label();
            this.HPP1 = new System.Windows.Forms.Label();
            this.HPP2 = new System.Windows.Forms.Label();
            this.chooseP1 = new System.Windows.Forms.ComboBox();
            this.chooseP2 = new System.Windows.Forms.ComboBox();
            this.start = new System.Windows.Forms.Button();
            this.Restart = new System.Windows.Forms.Button();
            this.tableresult = new System.Windows.Forms.DataGridView();
            this.movp1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.point1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.winner = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.point2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.movp2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.tableresult)).BeginInit();
            this.SuspendLayout();
            // 
            // Title
            // 
            this.Title.AutoSize = true;
            this.Title.Font = new System.Drawing.Font("Orbix", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Title.Location = new System.Drawing.Point(216, 21);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(369, 30);
            this.Title.TabIndex = 0;
            this.Title.Text = "Rock Paper Scissors Evoled";
            // 
            // instructions
            // 
            this.instructions.AutoSize = true;
            this.instructions.Font = new System.Drawing.Font("Microsoft Tai Le", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.instructions.Location = new System.Drawing.Point(12, 405);
            this.instructions.Name = "instructions";
            this.instructions.Size = new System.Drawing.Size(104, 33);
            this.instructions.TabIndex = 1;
            this.instructions.Text = "Instrucciones";
            this.instructions.UseVisualStyleBackColor = true;
            // 
            // labelPlayer1
            // 
            this.labelPlayer1.AutoSize = true;
            this.labelPlayer1.Font = new System.Drawing.Font("Orbix", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPlayer1.Location = new System.Drawing.Point(64, 128);
            this.labelPlayer1.Name = "labelPlayer1";
            this.labelPlayer1.Size = new System.Drawing.Size(88, 23);
            this.labelPlayer1.TabIndex = 2;
            this.labelPlayer1.Text = "Player 1";
            // 
            // labelplayer2
            // 
            this.labelplayer2.AutoSize = true;
            this.labelplayer2.Font = new System.Drawing.Font("Orbix", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelplayer2.Location = new System.Drawing.Point(596, 128);
            this.labelplayer2.Name = "labelplayer2";
            this.labelplayer2.Size = new System.Drawing.Size(93, 23);
            this.labelplayer2.TabIndex = 3;
            this.labelplayer2.Text = "Player 2";
            // 
            // HPP1
            // 
            this.HPP1.AutoSize = true;
            this.HPP1.Font = new System.Drawing.Font("Orbix", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HPP1.ForeColor = System.Drawing.Color.Red;
            this.HPP1.Location = new System.Drawing.Point(156, 128);
            this.HPP1.Name = "HPP1";
            this.HPP1.Size = new System.Drawing.Size(41, 23);
            this.HPP1.TabIndex = 4;
            this.HPP1.Text = "HP:";
            // 
            // HPP2
            // 
            this.HPP2.AutoSize = true;
            this.HPP2.Font = new System.Drawing.Font("Orbix", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HPP2.ForeColor = System.Drawing.Color.Red;
            this.HPP2.Location = new System.Drawing.Point(695, 128);
            this.HPP2.Name = "HPP2";
            this.HPP2.Size = new System.Drawing.Size(41, 23);
            this.HPP2.TabIndex = 5;
            this.HPP2.Text = "HP:";
            // 
            // chooseP1
            // 
            this.chooseP1.Font = new System.Drawing.Font("Microsoft Tai Le", 11.25F);
            this.chooseP1.FormattingEnabled = true;
            this.chooseP1.Location = new System.Drawing.Point(49, 164);
            this.chooseP1.Name = "chooseP1";
            this.chooseP1.Size = new System.Drawing.Size(157, 27);
            this.chooseP1.TabIndex = 6;
            // 
            // chooseP2
            // 
            this.chooseP2.Font = new System.Drawing.Font("Microsoft Tai Le", 11.25F);
            this.chooseP2.FormattingEnabled = true;
            this.chooseP2.Location = new System.Drawing.Point(587, 164);
            this.chooseP2.Name = "chooseP2";
            this.chooseP2.Size = new System.Drawing.Size(157, 27);
            this.chooseP2.TabIndex = 7;
            // 
            // start
            // 
            this.start.AutoSize = true;
            this.start.BackColor = System.Drawing.Color.DarkGreen;
            this.start.Font = new System.Drawing.Font("Microsoft Tai Le", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.start.ForeColor = System.Drawing.Color.White;
            this.start.Location = new System.Drawing.Point(348, 162);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(104, 33);
            this.start.TabIndex = 8;
            this.start.Text = "Comenzar";
            this.start.UseVisualStyleBackColor = false;
            // 
            // Restart
            // 
            this.Restart.AutoSize = true;
            this.Restart.BackColor = System.Drawing.Color.Red;
            this.Restart.Font = new System.Drawing.Font("Microsoft Tai Le", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Restart.ForeColor = System.Drawing.Color.White;
            this.Restart.Location = new System.Drawing.Point(684, 405);
            this.Restart.Name = "Restart";
            this.Restart.Size = new System.Drawing.Size(104, 33);
            this.Restart.TabIndex = 9;
            this.Restart.Text = "Reiniciar";
            this.Restart.UseVisualStyleBackColor = false;
            // 
            // tableresult
            // 
            this.tableresult.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.tableresult.BackgroundColor = System.Drawing.Color.YellowGreen;
            this.tableresult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableresult.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.movp1,
            this.point1,
            this.winner,
            this.point2,
            this.movp2});
            this.tableresult.EnableHeadersVisualStyles = false;
            this.tableresult.Location = new System.Drawing.Point(135, 221);
            this.tableresult.Name = "tableresult";
            this.tableresult.ReadOnly = true;
            this.tableresult.RowHeadersVisible = false;
            this.tableresult.Size = new System.Drawing.Size(531, 217);
            this.tableresult.TabIndex = 10;
            this.tableresult.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // movp1
            // 
            this.movp1.HeaderText = "Player 1";
            this.movp1.Name = "movp1";
            this.movp1.ReadOnly = true;
            // 
            // point1
            // 
            this.point1.HeaderText = "Puntos";
            this.point1.Name = "point1";
            this.point1.ReadOnly = true;
            // 
            // winner
            // 
            this.winner.HeaderText = "Ganador";
            this.winner.Name = "winner";
            this.winner.ReadOnly = true;
            // 
            // point2
            // 
            this.point2.HeaderText = "Puntos";
            this.point2.Name = "point2";
            this.point2.ReadOnly = true;
            // 
            // movp2
            // 
            this.movp2.HeaderText = "Player 2";
            this.movp2.Name = "movp2";
            this.movp2.ReadOnly = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.YellowGreen;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tableresult);
            this.Controls.Add(this.Restart);
            this.Controls.Add(this.start);
            this.Controls.Add(this.chooseP2);
            this.Controls.Add(this.chooseP1);
            this.Controls.Add(this.HPP2);
            this.Controls.Add(this.HPP1);
            this.Controls.Add(this.labelplayer2);
            this.Controls.Add(this.labelPlayer1);
            this.Controls.Add(this.instructions);
            this.Controls.Add(this.Title);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.tableresult)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Title;
        private System.Windows.Forms.Button instructions;
        private System.Windows.Forms.Label labelPlayer1;
        private System.Windows.Forms.Label labelplayer2;
        private System.Windows.Forms.Label HPP1;
        private System.Windows.Forms.Label HPP2;
        private System.Windows.Forms.ComboBox chooseP1;
        private System.Windows.Forms.ComboBox chooseP2;
        private System.Windows.Forms.Button start;
        private System.Windows.Forms.Button Restart;
        private System.Windows.Forms.DataGridView tableresult;
        private System.Windows.Forms.DataGridViewTextBoxColumn movp1;
        private System.Windows.Forms.DataGridViewTextBoxColumn point1;
        private System.Windows.Forms.DataGridViewTextBoxColumn winner;
        private System.Windows.Forms.DataGridViewTextBoxColumn point2;
        private System.Windows.Forms.DataGridViewTextBoxColumn movp2;
    }
}

