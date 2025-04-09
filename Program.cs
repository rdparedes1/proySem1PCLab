class ProyectoPcLab {
    static void Main(){
        // definimos las características del jugador
        string nombrePlayer = "";
        int hpPlayer = 0;
        int atqPlayer = 0;
        bool continuar = true;
        int kills = 0;
        int continuar1 = 0;
        int abrirCofre = 0;
        int probabilidadCofres = 0;
        Random rnd = new Random();
        int eleccionOpcionCombate = 0;
        Enemigo enemigoAc = new Enemigo();
        //Menu de elección de personaje.
        Console.WriteLine(@"Bienvenido al simulador de aventuras:
                            Elige una clase:
                            1) Mago 
                            2) Caballero
                            3) Arquera
                            (escribe la opción con números) ");
        int opcion = (int.Parse(Console.ReadLine()));
        //Console.WriteLine("Opción elegida: " + opcion);
        // clases de los jugadores mago, caballero y arquero
        switch(opcion){
            case 1:
            nombrePlayer = "Mago";
            hpPlayer = 1000;
            atqPlayer = 20;
                break;
            case 2:
            nombrePlayer = "Caballero";
            hpPlayer = 70;
            atqPlayer = 30;
                break;
            case 3:
            nombrePlayer = "Arquera";
            hpPlayer = 85;
            atqPlayer = 25; 
                break;
        }

        //Menú de elección de camino para la aventura
        Console.WriteLine(@"Elija un camino:
            1. Bosque oscuro
            2. Cueva sombría
            3. Camino de piedra
        ");
        int camino = (int.Parse(Console.ReadLine()));
        switch (camino){
            case 1:
            Console.WriteLine("Elegiste el Bosque oscuro");
                break;
            case 2:
            Console.WriteLine("Elegiste la Cueva sombría");
                break;
            case 3:
            Console.WriteLine("Elegiste el Camino de piedra");
                break;
        }
        // ciclo de continuar la partida
        while(continuar){
            Console.WriteLine($"Personaje elegido: {nombrePlayer}, puntos de salud actuales: {hpPlayer}, puntos de poder: {atqPlayer}, enemigos derrotados {kills} y el camino elegido es {camino}");
            Console.WriteLine(@"¿Quieres continuar la aventura?
                                1) si
                                2) no");
            continuar1 = (int.Parse(Console.ReadLine()));
            //Ciclo de luchas hasta la derrota del jugador o hasta la victoria de este.
            if(continuar1 == 1){
                continuar = true;
                //En base a la cantidad de enemigos derrotados se asigna a un enemigo contra el que se luchara.
                switch(kills){
                    case 0:
                        enemigoAc.setNombreEnemigo("Bandido");
                        enemigoAc.setHpEnemigo(30);
                        enemigoAc.setAtqEnemigo(rnd.Next(5,21));
                        //Console.WriteLine("Nombre enemigo: " + enemigoAc.getNombreEnemigo());
                        //Console.WriteLine("Vida enemigo: " + enemigoAc.getHpEnemigo());
                        //Console.WriteLine("Ataque enemigo: " + enemigoAc.getAtqEnemigo());
                        break;
                    case 1:
                        enemigoAc.setNombreEnemigo("Monstruo");
                        enemigoAc.setHpEnemigo(50);
                        enemigoAc.setAtqEnemigo(rnd.Next(10,31));
                        break;
                    case 2: 
                        enemigoAc.setNombreEnemigo("Jefe final");
                        enemigoAc.setHpEnemigo(70);
                        enemigoAc.setAtqEnemigo(rnd.Next(30,51));
                        break;
                }
                // menú de inicio de combate
                Console.WriteLine(@"Hay un nuevo oponente, ¿Quieres iniciar el combate?.
                                    Seleccione una opción:
                                    1. Luchar
                                    2. Huir");
                eleccionOpcionCombate = (int.Parse(Console.ReadLine()));
                if(eleccionOpcionCombate == 1){
                    while(0 < hpPlayer && 0 < enemigoAc.getHpEnemigo()){
                        if(camino == 2){
                            hpPlayer = hpPlayer - enemigoAc.getAtqEnemigo();
                            enemigoAc.setHpEnemigo(enemigoAc.getHpEnemigo() - atqPlayer);
                        } else {
                            enemigoAc.setHpEnemigo(enemigoAc.getHpEnemigo() - atqPlayer);
                            hpPlayer = hpPlayer - enemigoAc.getAtqEnemigo();
                        }
                    }
                    // condición de kills y cofres
                    if(hpPlayer > 0 && kills < 3){
                        Console.WriteLine("Has ganado el combate contra " + enemigoAc.getNombreEnemigo());
                        kills++;
                        if(kills == 3) {
                            continuar = false;
                            Console.WriteLine("Ha ganado los combates fin del juego");
                            break;
                        }
                        Console.WriteLine(@"Ha aparecido un cofre misterioso. ¿Quiere abrirlo?
                                            1. Abrir
                                            2. Dejar cerrado
                        ");
                        abrirCofre = int.Parse(Console.ReadLine());
                        if(abrirCofre == 1){
                            probabilidadCofres = rnd.Next(101);
                            //Esto varia con el camino número 3, así que hay una posibilidad más al momento de abrir el cofre.
                            if(camino == 3){
                                if(probabilidadCofres <= 25){
                                    Console.WriteLine("El cofre contenia energía, obtienes 10 de vida extra");
                                    hpPlayer = hpPlayer + 10;
                                } else if(26 <= probabilidadCofres && probabilidadCofres <= 50){
                                    Console.WriteLine("El cofre tenia poder, obtienes 5 de poder de ataque extra");
                                    atqPlayer = atqPlayer + 5;
                                } else if(51 <= probabilidadCofres && probabilidadCofres <= 75) {
                                    Console.WriteLine("El cofre conntenia veneno, pierdes 5 de vida");
                                    hpPlayer = hpPlayer - 5;
                                } else if(probabilidadCofres >=  76){
                                    Console.WriteLine("El cofre estaba vacio, no obtienes ninguna recompensa.");
                                }
                            }
                            else {
                                if (probabilidadCofres <= 33){
                                    Console.WriteLine("El cofre tenía energía, obtienes 10hp");
                                    hpPlayer = hpPlayer + 10;
                                }
                                else if (34 <= probabilidadCofres && probabilidadCofres <= 67){
                                    Console.WriteLine("El cofre tenía poder obtienes 5 de ataque extra");
                                    atqPlayer = atqPlayer + 5;
                                } else if (68<= probabilidadCofres && probabilidadCofres <= 100){
                                    Console.WriteLine("El cofre contenía veneno, pierdes 5hp");
                                    hpPlayer = hpPlayer - 5;
                                }                           
                            }
                        }    
                        // condición en el caso la vida del jugador llegue a cero      
                    } else if (hpPlayer <= 0) {
                        Console.WriteLine("Ha muerto, fin del juego");
                        continuar = false;
                    } else {
                        Console.WriteLine("Has ganado el juego, fin del juego.");
                        continuar = false;
                    }
                    // condición de huida
                } else if(eleccionOpcionCombate == 2) {
                    Console.WriteLine("Has huido del combate, pero pierdes 10 de hp");
                    hpPlayer = hpPlayer - 10;
                    if (hpPlayer <= 0){
                        Console.WriteLine("Haz muerto, termina la partida.");
                        continuar = false;
                    }
                }
                // en el caso se decida acabar la partida 
            } else if (continuar1 == 2) {
                Console.WriteLine("Ha decidido abandonar la aventura, fin del juego.");
                continuar = false;
            }
        }

    } 
}

//Clase de enemigo, usada por medio de instancia en el metodo main.
public class Enemigo {
    private string nombreEnemigo;
    private int hpEnemigo;
    private int atqEnemigo;

    public Enemigo() {
        this.nombreEnemigo = nombreEnemigo;
        this.hpEnemigo = hpEnemigo;
        this.atqEnemigo = atqEnemigo;
    }
    public string getNombreEnemigo(){
        return nombreEnemigo;
    }
    public int getHpEnemigo(){
        return hpEnemigo;
    }
    public int getAtqEnemigo(){
        return atqEnemigo;
    }


    public void setNombreEnemigo(string nombreEnemigo){
        this.nombreEnemigo = nombreEnemigo;
    }
    public void setHpEnemigo(int hpEnemigo){
        this.hpEnemigo = hpEnemigo;
    }
    public void setAtqEnemigo(int atqEnemigo){
        this.atqEnemigo = atqEnemigo;
    }

    public void causarDano(int dano){
        hpEnemigo = hpEnemigo - dano;
    }
}