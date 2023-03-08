package org.example;

public class Main {
    public static void main(String[] args) {
        Race race = new Race(1000);
        race.prepare();
        Racer winner = null;

        while(winner == null){
            race.simulate();
            winner = race.getWinner();
        }
        System.out.println("Ganador: " + winner.getName());

    }
}