using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Play_Paper__Rock__Scissors_Evoled
{

    //Hola este es un comentario, 
    public partial class Form1 : Form
    {
        // -------------------------
        // Variables globales
        // -------------------------
        private int hpP1 = 50;                       // HP actual del Jugador 1
        private int hpP2 = 50;                       // HP actual del Jugador 2 / CPU
        private Random rnd = new Random();           // Generador aleatorio para la CPU
        private bool modoHP = true;                  // true = modo HP (daños 1/3/5), false = modo tradicional (vidas=5, daño=1)
        private bool vsCPU = true;                   // true = jugar contra CPU, false = P1 vs P2 local

        // Orden y relaciones: 1=Piedra,2=Fuego,3=Tijera,4=Esponja,5=Papel,6=Aire,7=Agua
        // Regla: cada elemento derrota a los siguientes 3 en la secuencia (con wrap-around).
        // Daños al derrotado según posición en la lista de derrotados: [1, 3, 5]
        private readonly string[] elementos = { "Piedra", "Fuego", "Tijera", "Esponja", "Papel", "Aire", "Agua" };

        public Form1()
        {
            InitializeComponent();

            // Asociar eventos si no están ligados desde el diseñador
            this.Load += Form1_Load;
            start.Click += start_Click;
            Restart.Click += Restart_Click;
            // Nota: el nombre del control de instrucciones en tu diseñador debe coincidir con 'instructions' o 'Instruccions'.
            // Aquí se asume que existe un control llamado 'instructions' y el manejador es Instruccions_Click.
            instructions.Click += Instruccions_Click;
        }

        // -------------------------
        // Mostrar configuración inicial
        // Pregunta al usuario si quiere modo por vidas o tradicional y si jugar contra CPU o Jugador 2
        // -------------------------
        private void MostrarConfiguracionInicial()
        {
            var modo = MessageBox.Show("¿Quieres jugar por vidas? (Sí = por vidas, No = tradicional)",
                                       "Selecciona modo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            modoHP = (modo == DialogResult.Yes);

            var oponente = MessageBox.Show("¿Jugar contra CPU? (Sí = CPU, No = Jugador 2)",
                                           "Selecciona oponente", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            vsCPU = (oponente == DialogResult.Yes);

            // Ajustes UI según elección: si es vsCPU, deshabilitar selección manual de P2
            chooseP2.Enabled = !vsCPU;
        }

        // -------------------------
        // Inicializar HP según el modo seleccionado
        // - En modo HP: valores por defecto (50)
        // - En modo tradicional: cada jugador tiene 5 vidas
        // También habilita el botón start al iniciar/reiniciar
        // -------------------------
        private void InicializarHP()
        {
            if (modoHP)
            {
                // Modo por vidas (HP) — valor por defecto 50
                hpP1 = 50;
                hpP2 = 50;
            }
            else
            {
                // Modo tradicional: cada jugador tiene 5 vidas
                hpP1 = 5;
                hpP2 = 5;
            }

            // Actualizar labels de HP en la interfaz
            HPP1.Text = hpP1.ToString();
            HPP2.Text = hpP2.ToString();

            // Asegurarse de que el botón start esté habilitado al comenzar
            start.Enabled = true;
        }

        // -------------------------
        // Evento Load del formulario
        // Inicializa ComboBoxes, muestra configuración y establece HP inicial
        // -------------------------
        private void Form1_Load(object sender, EventArgs e)
        {
            // Inicializar ComboBoxes con las opciones
            chooseP1.Items.AddRange(elementos);
            chooseP2.Items.AddRange(elementos);
            chooseP1.SelectedIndex = 0;
            chooseP2.SelectedIndex = 0;

            // Mostrar configuración inicial antes de inicializar HP
            MostrarConfiguracionInicial();

            // Inicializar HP según la configuración elegida
            InicializarHP();
        }

        // -------------------------
        // Evaluar la ronda: devuelve (dañoA, dañoB, ganador)
        // - dañoA = daño que hace movA sobre movB
        // - dañoB = daño que hace movB sobre movA
        // - ganador = "Jugador1", "Jugador2" o "Empate"
        // -------------------------
        private (int dañoA, int dañoB, string ganador) EvaluarRonda(string movA, string movB)
        {
            // Empate: mismo movimiento -> daño 0
            if (movA == movB) return (0, 0, "Empate");

            // Obtener índices en la lista (0..6)
            int idxA = Array.IndexOf(elementos, movA);
            int idxB = Array.IndexOf(elementos, movB);

            // Lista de derrotados por A: idxA+1, idxA+2, idxA+3 (mod 7)
            List<int> derrotadosA = new List<int> {
                (idxA + 1) % 7,
                (idxA + 2) % 7,
                (idxA + 3) % 7
            };

            // Si B está en la lista de derrotados por A, A hace daño a B
            int posEnDerrotados = derrotadosA.IndexOf(idxB); // 0,1,2 o -1
            if (posEnDerrotados >= 0)
            {
                // Según tu ejemplo: daños = [1,3,5] para las posiciones 0,1,2 respectivamente
                int[] daños = { 1, 3, 5 };
                int dañoA = daños[posEnDerrotados];
                return (dañoA, 0, "Jugador1");
            }

            // Si no, entonces B derrota a A (relación simétrica)
            List<int> derrotadosB = new List<int> {
                (idxB + 1) % 7,
                (idxB + 2) % 7,
                (idxB + 3) % 7
            };
            int posEnDerrotadosB = derrotadosB.IndexOf(idxA);
            if (posEnDerrotadosB >= 0)
            {
                int[] daños = { 1, 3, 5 };
                int dañoB = daños[posEnDerrotadosB];
                return (0, dañoB, "Jugador2");
            }

            // Fallback (no debería ocurrir)
            return (0, 0, "Empate");
        }

        // -------------------------
        // Manejador del botón start
        // - Valida selecciones
        // - Si es vsCPU genera elección de la CPU
        // - Evalúa la ronda y aplica daños según el modo
        // - En modo tradicional: daño por victoria = 1 (vidas)
        // - Si alguien llega a 0, deshabilita start y muestra mensaje final
        // -------------------------
        private void start_Click(object sender, EventArgs e)
        {
            // Validaciones de selección
            if (chooseP1.SelectedItem == null)
            {
                MessageBox.Show("Introduzca una opción para el Jugador 1", "Aviso");
                return;
            }
            if (!vsCPU && chooseP2.SelectedItem == null)
            {
                MessageBox.Show("Introduzca una opción para el Jugador 2", "Aviso");
                return;
            }

            // Si es vs CPU, generar elección aleatoria y mostrarla en chooseP2
            if (vsCPU)
            {
                string eleccionCPU = elementos[rnd.Next(elementos.Length)];
                chooseP2.SelectedItem = eleccionCPU;
                chooseP2.Text = eleccionCPU;
            }

            // Leer movimientos seleccionados
            string movP1 = chooseP1.SelectedItem.ToString();
            string movP2 = chooseP2.SelectedItem.ToString();

            // Evaluar ronda (daños según la tabla 1/3/5)
            var resultado = EvaluarRonda(movP1, movP2);
            int dañoP1 = resultado.dañoA;   // daño que hace P1 sobre P2 según EvaluarRonda
            int dañoP2 = resultado.dañoB;   // daño que hace P2 sobre P1 según EvaluarRonda
            string ganador = resultado.ganador;

            // Si estamos en modo tradicional (no modoHP), el daño por victoria es siempre 1
            if (!modoHP)
            {
                dañoP1 = (resultado.dañoA > 0) ? 1 : 0;
                dañoP2 = (resultado.dañoB > 0) ? 1 : 0;
            }

            // Aplicar efectos: restar vida según daño calculado (ambos modos usan hpP1/hpP2)
            hpP1 -= dañoP2; // P2 hace daño a P1
            hpP2 -= dañoP1; // P1 hace daño a P2

            // Evitar valores negativos
            if (hpP1 < 0) hpP1 = 0;
            if (hpP2 < 0) hpP2 = 0;

            // Actualizar labels de HP en la interfaz
            HPP1.Text = hpP1.ToString();
            HPP2.Text = hpP2.ToString();

            // En modo instantáneo (si lo deseas mantener como "victoria inmediata"),
            // ya hemos convertido el daño a 1/0 en la sección anterior, por lo que la lógica queda consistente.

            // Determinar texto de resultado para mostrar al usuario
            string textoResultado;
            if (ganador == "Empate")
                textoResultado = "Empate. No hay daño.";
            else if (ganador == "Jugador1")
                textoResultado = "Ganó Jugador 1";
            else
                textoResultado = "Ganó Jugador 2";

            // Mostrar resultado de la ronda
            MessageBox.Show(textoResultado, "Resultado");

            // Registrar en DataGridView tableresult (columnas: movp1, point1, winner, point2, movp2)
            tableresult.Rows.Add(movP1, dañoP1, ganador, dañoP2, movP2);

            // Comprobar fin de partida: si alguien llegó a 0 HP, deshabilitar start y avisar
            if (hpP1 == 0 || hpP2 == 0)
            {
                // Deshabilitar el botón start para evitar continuar la partida
                start.Enabled = false;

                // Determinar ganador final y mostrar mensaje indicando que presione Reiniciar
                string ganadorFinal;
                if (hpP1 == 0 && hpP2 == 0) ganadorFinal = "Empate final. Ambos llegaron a 0 vidas.";
                else if (hpP2 == 0) ganadorFinal = "Jugador 1 gana la partida.";
                else ganadorFinal = "Jugador 2 gana la partida.";

                MessageBox.Show(ganadorFinal + "\nPresiona Reiniciar para comenzar de nuevo.", "Partida finalizada");
            }
        }

        // -------------------------
        // Reiniciar partida
        // - Vuelve a inicializar HP según el modo actual
        // - Limpia el DataGridView y restablece selecciones
        // - Vuelve a preguntar configuración inicial (opcional)
        // -------------------------
        private void Restart_Click(object sender, EventArgs e)
        {
            // Reinicializar HP según el modo actual (50 o 5)
            InicializarHP();

            // Limpiar historial en la tabla de resultados
            tableresult.Rows.Clear();

            // Restablecer selecciones a la primera opción
            chooseP1.SelectedIndex = 0;
            chooseP2.SelectedIndex = 0;

            // Volver a preguntar configuración inicial (opcional)
            MostrarConfiguracionInicial();

            // Si la configuración cambió, volver a inicializar HP con la nueva configuración
            InicializarHP();
        }

        // -------------------------
        // Mostrar instrucciones
        // -------------------------
        private void Instruccions_Click(object sender, EventArgs e)
        {
            string texto = "Reglas resumidas:\n\n" +
                           "- Empate si ambos eligen lo mismo (daño 0).\n" +
                           "- Modo Instantáneo / Tradicional: cada jugador tiene 5 vidas y cada victoria resta 1 vida.\n" +
                           "- Modo HP: cada movimiento aplica daño según la tabla interna (1, 3 o 5). Cada jugador empieza con 50 HP.\n" +
                           "- Puedes jugar contra CPU (elección aleatoria) o contra Jugador 2 (local).\n\n" +
                           "Orden de elementos y relaciones:\n" +
                           "Piedra -> Fuego, Tijera, Esponja\n" +
                           "Fuego -> Tijera, Esponja, Papel\n" +
                           "Tijera -> Esponja, Papel, Aire\n" +
                           "Esponja -> Papel, Aire, Agua\n" +
                           "Papel -> Aire, Agua, Piedra\n" +
                           "Aire -> Agua, Piedra, Fuego\n" +
                           "Agua -> Piedra, Fuego, Tijera\n\n" +
                           "Daños al derrotado según cercanía en la lista: 1 (débil), 3 (medio), 5 (fuerte).";
            MessageBox.Show(texto, "Instrucciones");
        }

        // (Opcional) manejador vacío si el DataGridView tiene eventos ligados
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
    }
}
