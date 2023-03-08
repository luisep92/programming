package org.example;

import java.util.Random;

public class Utils {
    public static Random r = new Random();
    public static boolean isEven(int n){
        return n % 2 == 0;
    }

    public static double randomRange(double min, double max){
        if(min > max)
            return randomRange(max, min);
        return r.nextDouble() * (max - min) + min;
    }
}
