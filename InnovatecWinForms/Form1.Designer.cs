namespace InnovatecWinForms
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
            this.btnInsertTree = new System.Windows.Forms.Button();
            this.btnSearchTree = new System.Windows.Forms.Button();
            this.btnCountTree = new System.Windows.Forms.Button();
            this.btnLevelTree = new System.Windows.Forms.Button();
            this.treeViewOrg = new System.Windows.Forms.TreeView();
            this.txtParent = new System.Windows.Forms.TextBox();
            this.txtNewNode = new System.Windows.Forms.TextBox();
            this.txtA = new System.Windows.Forms.TextBox();
            this.txtB = new System.Windows.Forms.TextBox();
            this.txtWeight = new System.Windows.Forms.TextBox();
            this.btnAddEdge = new System.Windows.Forms.Button();
            this.lstAdj = new System.Windows.Forms.ListBox();
            this.txtStart = new System.Windows.Forms.TextBox();
            this.txtEnd = new System.Windows.Forms.TextBox();
            this.btnShortestPath = new System.Windows.Forms.Button();
            this.lblResult = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnInsertTree
            // 
            this.btnInsertTree.Location = new System.Drawing.Point(356, 117);
            this.btnInsertTree.Name = "btnInsertTree";
            this.btnInsertTree.Size = new System.Drawing.Size(81, 31);
            this.btnInsertTree.TabIndex = 0;
            this.btnInsertTree.Text = "Insertar";
            this.btnInsertTree.UseVisualStyleBackColor = true;
            this.btnInsertTree.Click += new System.EventHandler(this.btnInsertTree_Click);
            // 
            // btnSearchTree
            // 
            this.btnSearchTree.Location = new System.Drawing.Point(461, 117);
            this.btnSearchTree.Name = "btnSearchTree";
            this.btnSearchTree.Size = new System.Drawing.Size(81, 31);
            this.btnSearchTree.TabIndex = 1;
            this.btnSearchTree.Text = "Buscar";
            this.btnSearchTree.UseVisualStyleBackColor = true;
            this.btnSearchTree.Click += new System.EventHandler(this.btnSearchTree_Click);
            // 
            // btnCountTree
            // 
            this.btnCountTree.Location = new System.Drawing.Point(661, 117);
            this.btnCountTree.Name = "btnCountTree";
            this.btnCountTree.Size = new System.Drawing.Size(127, 31);
            this.btnCountTree.TabIndex = 2;
            this.btnCountTree.Text = "Contar nodos";
            this.btnCountTree.UseVisualStyleBackColor = true;
            this.btnCountTree.Click += new System.EventHandler(this.btnCountTree_Click);
            // 
            // btnLevelTree
            // 
            this.btnLevelTree.Location = new System.Drawing.Point(562, 117);
            this.btnLevelTree.Name = "btnLevelTree";
            this.btnLevelTree.Size = new System.Drawing.Size(78, 31);
            this.btnLevelTree.TabIndex = 3;
            this.btnLevelTree.Text = "Nivel";
            this.btnLevelTree.UseVisualStyleBackColor = true;
            this.btnLevelTree.Click += new System.EventHandler(this.btnLevelTree_Click);
            // 
            // treeViewOrg
            // 
            this.treeViewOrg.Location = new System.Drawing.Point(37, 12);
            this.treeViewOrg.Name = "treeViewOrg";
            this.treeViewOrg.Size = new System.Drawing.Size(272, 160);
            this.treeViewOrg.TabIndex = 4;
            // 
            // txtParent
            // 
            this.txtParent.Location = new System.Drawing.Point(356, 12);
            this.txtParent.Name = "txtParent";
            this.txtParent.Size = new System.Drawing.Size(100, 20);
            this.txtParent.TabIndex = 5;
            // 
            // txtNewNode
            // 
            this.txtNewNode.Location = new System.Drawing.Point(356, 61);
            this.txtNewNode.Name = "txtNewNode";
            this.txtNewNode.Size = new System.Drawing.Size(100, 20);
            this.txtNewNode.TabIndex = 6;
            // 
            // txtA
            // 
            this.txtA.Location = new System.Drawing.Point(356, 199);
            this.txtA.Name = "txtA";
            this.txtA.Size = new System.Drawing.Size(100, 20);
            this.txtA.TabIndex = 7;
            // 
            // txtB
            // 
            this.txtB.Location = new System.Drawing.Point(356, 246);
            this.txtB.Name = "txtB";
            this.txtB.Size = new System.Drawing.Size(100, 20);
            this.txtB.TabIndex = 8;
            // 
            // txtWeight
            // 
            this.txtWeight.Location = new System.Drawing.Point(356, 291);
            this.txtWeight.Name = "txtWeight";
            this.txtWeight.Size = new System.Drawing.Size(100, 20);
            this.txtWeight.TabIndex = 9;
            // 
            // btnAddEdge
            // 
            this.btnAddEdge.Location = new System.Drawing.Point(356, 334);
            this.btnAddEdge.Name = "btnAddEdge";
            this.btnAddEdge.Size = new System.Drawing.Size(100, 23);
            this.btnAddEdge.TabIndex = 10;
            this.btnAddEdge.Text = "Agregar conexión";
            this.btnAddEdge.UseVisualStyleBackColor = true;
            this.btnAddEdge.Click += new System.EventHandler(this.btnAddEdge_Click);
            // 
            // lstAdj
            // 
            this.lstAdj.FormattingEnabled = true;
            this.lstAdj.Location = new System.Drawing.Point(37, 199);
            this.lstAdj.Name = "lstAdj";
            this.lstAdj.Size = new System.Drawing.Size(272, 212);
            this.lstAdj.TabIndex = 11;
            // 
            // txtStart
            // 
            this.txtStart.Location = new System.Drawing.Point(515, 199);
            this.txtStart.Name = "txtStart";
            this.txtStart.Size = new System.Drawing.Size(100, 20);
            this.txtStart.TabIndex = 12;
            // 
            // txtEnd
            // 
            this.txtEnd.Location = new System.Drawing.Point(515, 246);
            this.txtEnd.Name = "txtEnd";
            this.txtEnd.Size = new System.Drawing.Size(100, 20);
            this.txtEnd.TabIndex = 13;
            // 
            // btnShortestPath
            // 
            this.btnShortestPath.Location = new System.Drawing.Point(515, 301);
            this.btnShortestPath.Name = "btnShortestPath";
            this.btnShortestPath.Size = new System.Drawing.Size(100, 23);
            this.btnShortestPath.TabIndex = 14;
            this.btnShortestPath.Text = "Ruta mas corta";
            this.btnShortestPath.UseVisualStyleBackColor = true;
            this.btnShortestPath.Click += new System.EventHandler(this.btnShortestPath_Click);
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResult.Location = new System.Drawing.Point(511, 334);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(62, 24);
            this.lblResult.TabIndex = 15;
            this.lblResult.Text = "Result";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(811, 432);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.btnShortestPath);
            this.Controls.Add(this.txtEnd);
            this.Controls.Add(this.txtStart);
            this.Controls.Add(this.lstAdj);
            this.Controls.Add(this.btnAddEdge);
            this.Controls.Add(this.txtWeight);
            this.Controls.Add(this.txtB);
            this.Controls.Add(this.txtA);
            this.Controls.Add(this.txtNewNode);
            this.Controls.Add(this.txtParent);
            this.Controls.Add(this.treeViewOrg);
            this.Controls.Add(this.btnLevelTree);
            this.Controls.Add(this.btnCountTree);
            this.Controls.Add(this.btnSearchTree);
            this.Controls.Add(this.btnInsertTree);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnInsertTree;
        private System.Windows.Forms.Button btnSearchTree;
        private System.Windows.Forms.Button btnCountTree;
        private System.Windows.Forms.Button btnLevelTree;
        private System.Windows.Forms.TreeView treeViewOrg;
        private System.Windows.Forms.TextBox txtParent;
        private System.Windows.Forms.TextBox txtNewNode;
        private System.Windows.Forms.TextBox txtA;
        private System.Windows.Forms.TextBox txtB;
        private System.Windows.Forms.TextBox txtWeight;
        private System.Windows.Forms.Button btnAddEdge;
        private System.Windows.Forms.ListBox lstAdj;
        private System.Windows.Forms.TextBox txtStart;
        private System.Windows.Forms.TextBox txtEnd;
        private System.Windows.Forms.Button btnShortestPath;
        private System.Windows.Forms.Label lblResult;
    }
}

