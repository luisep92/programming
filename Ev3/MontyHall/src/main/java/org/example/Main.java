package org.example;

public class Main {
    public static void main(String[] args) {
        int times = 1000000;
        Game game = new Game(3);
        System.out.println("Si ejecutamos la prueba cambiando la puerta cada vez, ganamos: " + game.Simulation(times,true) + " / " + times);
        System.out.println("Si ejecutamos la prueba sin cambiar la puerta cada vez, ganamos: " + game.Simulation(times,false)+ " / " + times);



    }

}