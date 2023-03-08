package org.example;

public abstract class Racer {
    String name;
    int age;
    double distance;

    public Racer(String name, int age){
        distance = 0;
        this.name = name;
        this.age = age;
    }

    public String getName(){
        return name;
    }

    public double getDistance(){
        return distance;
    }
    public void setDistance(double n){
        if(n >= 0){
            distance = n;
        }
        else{
            distance = 0;
        }
    }

    public abstract void simulate();
}
