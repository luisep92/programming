package org.example;

public class Cojo extends Racer{
    boolean isGrounded;

    public Cojo(String name, int age){
        super(name, age);
        isGrounded = false;
    }
    @Override
    public void simulate() {
        if(isGrounded){
            isGrounded = false;
        }
        else if(Utils.randomRange(0,100) < 15){
            isGrounded = true;
        }
        else{
            setDistance(getDistance() + 2);
        }
    }
}
