package org.example;

import java.util.ArrayList;
import java.util.List;

public class Race {
    double distance;
    List<Racer> racers;

    public Race(double distance){
        this.distance = distance;
        racers = new ArrayList<>();
    }

    public void addRacer(Racer r){
        racers.add(r);
    }

    Racer getWinner(){
        for (Racer r : racers){
            if(r.getDistance() >= this.distance){
                return r;
            }
        }
        return null;
    }

    public void simulate(){
        for (Racer r : racers){
            r.simulate();
        }
    }

    public void prepare(){
        racers.add(new Cojo("Cojo", 23));
        racers.add(new Patapalo("Patapalo", 24));
    }

}
