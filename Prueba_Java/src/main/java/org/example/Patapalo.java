package org.example;

public class Patapalo extends Racer{
    int turn;

    public Patapalo(String name, int age){
        super(name, age);
        turn = 0;
    }
    @Override
    public void simulate() {
        double d;
        turn++;
        if(Utils.isEven(turn))
            d = 2;
        else
            d = 1;
        setDistance(getDistance() + d);
        System.out.println(d);
    }
}
