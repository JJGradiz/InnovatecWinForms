using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InnovatecWinForms
{
    public partial class InnoVatecPark : Form
    {
        GeneralTree<string> org;
        Graph graph;

        public InnoVatecPark()
        {
            InitializeComponent();

            org = new GeneralTree<string>("CEO");
            graph = new Graph();

            LoadTreeView();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void LoadTreeView()
        {
            treeViewOrg.Nodes.Clear();
            TreeNode root = new TreeNode(org.Root.Value);
            treeViewOrg.Nodes.Add(root);
            LoadChildren(root, org.Root);
            treeViewOrg.ExpandAll();
        }

        private void LoadChildren(TreeNode visualNode, TreeNode<string> modelNode)
        {
            foreach (var child in modelNode.Children)
            {
                TreeNode newNode = new TreeNode(child.Value);
                visualNode.Nodes.Add(newNode);
                LoadChildren(newNode, child);
            }
        }

        private void btnInsertTree_Click(object sender, EventArgs e)
        {
            if (org.Insert(txtParent.Text, txtNewNode.Text))
            {
                LoadTreeView();
                MessageBox.Show("Nodo insertado correctamente.");
            }
            else
            {
                MessageBox.Show("Nodo padre no encontrado.");
            }
        }

        private void btnSearchTree_Click(object sender, EventArgs e)
        {
            bool found = org.Contains(txtNewNode.Text);
            MessageBox.Show(found ? "Encontrado." : "No encontrado.");
        }

        private void btnCountTree_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Total nodos: " + org.Count());
        }

        private void btnLevelTree_Click(object sender, EventArgs e)
        {
            int lvl = org.LevelOf(txtNewNode.Text);
            MessageBox.Show("Nivel: " + lvl);
        }

        private void btnAddEdge_Click(object sender, EventArgs e)
        {
            string a = txtA.Text.Trim();
            string b = txtB.Text.Trim();

            if (string.IsNullOrEmpty(a) || string.IsNullOrEmpty(b))
            {
                MessageBox.Show("Introduce valores válidos para los nodos A y B.");
                return;
            }

            if (!double.TryParse(txtWeight.Text, out double weight))
            {
                MessageBox.Show("Peso inválido. Introduce un número válido (por ejemplo: 2.5).");
                return;
            }

            try
            {
                graph.AddEdge(a, b, weight);
                LoadGraphAdj();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al añadir la arista: " + ex.Message);
            }
        }

        private void LoadGraphAdj()
        {
            lstAdj.Items.Clear();

            var all = graph.GetAll();
            if (all == null || all.Count == 0)
            {
                lstAdj.Items.Add("(Grafo vacío)");
                return;
            }

            foreach (var kv in all)
            {
                string line = kv.Key + " -> " +
                    string.Join(", ", kv.Value.Select(e => $"{e.To}({e.Weight})"));
                lstAdj.Items.Add(line);
            }
        }

        private void btnShortestPath_Click(object sender, EventArgs e)
        {
            string start = txtStart.Text.Trim();
            string end = txtEnd.Text.Trim();

            if (string.IsNullOrEmpty(start) || string.IsNullOrEmpty(end))
            {
                MessageBox.Show("Introduce nodo origen y destino.");
                return;
            }

            var all = graph.GetAll();
            if (!all.ContainsKey(start) || !all.ContainsKey(end))
            {
                MessageBox.Show("El nodo origen o destino no existe en el grafo.");
                return;
            }

            try
            {
                var (dist, path) = graph.Dijkstra(start, end);

                if (path == null || path.Count == 0 || double.IsInfinity(dist))
                {
                    lblResult.Text = "No existe ruta.";
                    return;
                }

                lblResult.Text = $"Ruta: {string.Join(" -> ", path)}  Dist = {dist}";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al calcular la ruta: " + ex.Message);
            }
        }
    }
}
