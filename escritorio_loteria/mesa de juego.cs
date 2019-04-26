using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace escritorio_loteria
{
    public partial class mesa_de_juego : Form
    {
        //contador para saber si se seleccionaon todas las cartas antes de ganar
        int contador_cartas = 0;

        //variable para guardar el nombre del jugador y la ip del servidor
        string jugador = "";
        string IP_server = "";

        //delegado para conectar los hilos con la interfaz principal 
        private delegate void Comunicacion(string s);

        private void hacerAlgo(string s)
        {
            switch (s)
            {
                default:
                    MessageBox.Show("si se envio el dato " + s);
                    break;
            }
        }

        #region cosas para el cliente;

        //objetos que se utilizan para conectar con el servidor
        Socket listen_cliente = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        IPEndPoint connect_cliente = null;

        #endregion;

        #region cosas para el server;
        //manejadores de sockets para conectar a los juadores
        Socket listen_server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        Socket conexion;
        IPEndPoint connect_server = new IPEndPoint(obtenerIP(), 8000);

        //lista para guardar a los jugadores que se van uniendo a la partida
        List<jugador_model> Clientes = new List<jugador_model>();

        #endregion;


        public mesa_de_juego(string jugadorPasado, string cliente)
        {
            InitializeComponent();

            //obtener el valor que envio el activity del menu
            jugador = jugadorPasado;

            carta1.Click += delegate { evaluar_carta(carta1); };
            carta2.Click += delegate { evaluar_carta(carta2); };
            carta3.Click += delegate { evaluar_carta(carta3); };
            carta4.Click += delegate { evaluar_carta(carta4); };
            carta5.Click += delegate { evaluar_carta(carta5); };
            carta6.Click += delegate { evaluar_carta(carta6); };
            carta7.Click += delegate { evaluar_carta(carta7); };
            carta8.Click += delegate { evaluar_carta(carta8); };
            carta9.Click += delegate { evaluar_carta(carta9); };
            carta10.Click += delegate { evaluar_carta(carta10); };
            carta11.Click += delegate { evaluar_carta(carta11); };
            carta12.Click += delegate { evaluar_carta(carta12); };
            carta13.Click += delegate { evaluar_carta(carta13); };
            carta14.Click += delegate { evaluar_carta(carta14); };
            carta15.Click += delegate { evaluar_carta(carta15); };
            carta16.Click += delegate { evaluar_carta(carta16); };

            //programa el boton de buenas
            btnBuenas.Click += delegate
            {
                if (contador_cartas == 16)
                {
                    reclamar_buenas();
                }
                else
                    MessageBox.Show("Aun no marcas todas las cartas");

            };

            //cargar el alert para conectarse con el servidor si se es cliente
            //si es server abre un alert para esperar a los clientes
            if (cliente == "si")
            {
                btnJugar.Click += delegate
                {
                    conectar(txtIPServer.Text);
                };
            }
            else
            {
                //obtener la ip del servidor para colocar en el textview
                var txt_IP = txtIPServer;
                txt_IP.Text += " " + obtenerIP();

                //colocar el nombre del jugador que creo la partida en la lista de jugadores
                txtJugadores.Text += jugador + "\r\n";

                //iniciar el servidor
                listen_server.Bind(connect_server);
                listen_server.Listen(20);

                var t = new Thread(espear_jugadores);
                t.Start();

                btnJugar.Click += async delegate
                {
                    //iniciar el hilo que espera a los jugadores por si alguien gana 
                    var ganador = new Thread(espear_ganador);
                    ganador.Start();

                    for (int i = 0; i < 3; i++)
                    {
                        enviar_carta(i);
                        //definir el tiempo que tarda en sacar las cartas 
                        await Task.Delay(3000);
                    }
                };
            }

        }

        public void evaluar_carta(PictureBox carta)
        {
            if (carta.Tag.ToString() == "0")
            {
                carta.Tag = 1;
                Image flipImage = carta.Image;
                flipImage.RotateFlip(RotateFlipType.Rotate90FlipXY);
                flipImage.RotateFlip(RotateFlipType.Rotate90FlipXY);
                carta.Image = flipImage;
                contador_cartas++;
            }
            else
            {
                carta.Tag = 0;
                Image flipImage = carta.Image;
                flipImage.RotateFlip(RotateFlipType.Rotate90FlipXY);
                flipImage.RotateFlip(RotateFlipType.Rotate90FlipXY);
                carta.Image = flipImage;
                contador_cartas--;
            }
        }

        void reclamar_buenas()
        {
            byte[] enviar_info = new byte[100];
            enviar_info = Encoding.Default.GetBytes("gane" + jugador);

            listen_cliente.Send(enviar_info);
        }

        void espear_ganador()
        {
            while (true)
            {
                //obtener el mensaje del servidor
                byte[] recibir_info = new byte[100];
                string data = "";
                int array_size = conexion.Receive(recibir_info, 0, recibir_info.Length, 0);
                Array.Resize(ref recibir_info, array_size);
                data = Encoding.Default.GetString(recibir_info);

                try
                {
                    this.Invoke(new Comunicacion(hacerAlgo), data);
                }
                catch (Exception)
                {
                    Console.WriteLine("No se pudo enviar la carta");
                }
            }
        }

        void espear_jugadores()
        {
            while (true)
            {
                Console.WriteLine("Work");
                //sabe si la conexion fue aceptada
                conexion = listen_server.Accept();
                Console.WriteLine("Conexion Aceptada");

                //obtener el mensaje del jugador que se acaba de unir
                byte[] recibir_info = new byte[100];
                string data = "";
                int array_size = conexion.Receive(recibir_info, 0, recibir_info.Length, 0);
                Array.Resize(ref recibir_info, array_size);
                data = Encoding.Default.GetString(recibir_info);

                //guardar el objeto del jugador en la lista para enviar las cartas cuando el juego comience (solo aplica cuando el juego no ha comenzado)
                if (!Clientes.Contains(new jugador_model
                {
                    nombre_jugador = data,
                    socket_jugador = conexion
                }))
                {
                    Clientes.Add(new jugador_model
                    {
                        nombre_jugador = data,
                        socket_jugador = conexion
                    });
                    Console.WriteLine("Nuevo: " + data);

                    try
                    {
                        this.Invoke(new Comunicacion(hacerAlgo), data + "\r\n");
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("No se pudo enviar la carta");
                    }
                }

            }
        }
        
        public bool enviar_carta(int carta)
        {
            byte[] mensaje = new byte[100];
            string data = "la carta es: " + carta;
            mensaje = Encoding.Default.GetBytes(data);
            Console.WriteLine(mensaje);

            foreach (var item in Clientes)
            {
                item.socket_jugador.Send(mensaje);
            }

            return true;
        }

        public void recibir_carta()
        {
            while (true)
            {
                //obtener el mensaje del servidor
                byte[] recibir_info = new byte[100];
                string data = "";
                int array_size = listen_cliente.Receive(recibir_info, 0, recibir_info.Length, 0);
                Array.Resize(ref recibir_info, array_size);
                data = Encoding.Default.GetString(recibir_info);

                try
                {
                    this.Invoke(new Comunicacion(hacerAlgo), data);
                }
                catch (Exception)
                {
                    Console.WriteLine("No se pudo enviar la carta");
                }
            }
        }

        public void conectar(string IP)
        {
            IP_server = IP;
            connect_cliente = new IPEndPoint(IPAddress.Parse(IP), 8000);
            listen_cliente.Connect(connect_cliente);
            byte[] enviar_info = new byte[100];

            enviar_info = Encoding.Default.GetBytes(jugador);

            listen_cliente.Send(enviar_info);

            Thread t = new Thread(recibir_carta);
            t.Start();
        }

        internal static IPAddress obtenerIP()
        {
            //IPAddress ipAddress = null;
            //var guardar = false;
            //foreach (NetworkInterface ni in NetworkInterface.GetAllNetworkInterfaces())
            //{
            //    if (ni.NetworkInterfaceType == NetworkInterfaceType.Wireless80211 || ni.NetworkInterfaceType == NetworkInterfaceType.Ethernet)
            //    {
            //        foreach (UnicastIPAddressInformation ip in ni.GetIPProperties().UnicastAddresses)
            //        {
            //            if (ip.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
            //            {
            //                if (!guardar)
            //                {
            //                    ipAddress = ip.Address;
            //                    guardar = true;
            //                    Console.WriteLine(ip.Address);
            //                }
            //            }
            //        }
            //    }
            //}
            //return ipAddress;

            IPHostEntry host;
            string localIP = "";
            host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily.ToString() == "InterNetwork")
                {
                    localIP = ip.ToString();
                }
            }

            return IPAddress.Parse(localIP);
        }

    }

    public class jugador_model
    {
        public string nombre_jugador { get; set; }
        public Socket socket_jugador { get; set; }
    }
}
