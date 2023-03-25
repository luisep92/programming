package org.example;
import java.util.Random;

public class Utils {
    static Random r = new Random();

    public static int RandomInt(int min, int max){
        if(min > max)
            return RandomInt(max, min);
        int n = (int)(r.nextDouble() * ((max+1) - min) + min);
        if(n > max)
            return RandomInt(min, max);
        return n;
    }
}
