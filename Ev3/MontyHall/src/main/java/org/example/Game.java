package org.example;

import java.util.ArrayList;
import java.util.List;

public class Game {
    public enum Door{CAR, CABRA}
    public enum GameResult{WIN, LOSE, UNKNOWN}

    public int selection;
    int doorsNumber;

    private List<Door> doors = new ArrayList<Door>();;

    public Game(int doorsNumber){
        init(doorsNumber);
        this.doorsNumber = doorsNumber;
        selection = Utils.RandomInt(0,doors.size() - 1);
    }

    void init(int doorsNumber){
        doors.clear();
        int rand = Utils.RandomInt(0,doorsNumber - 1);
        for(int i = 0; i < doorsNumber; i++){
            if(i == rand)
                doors.add(Door.CAR);
            else
                doors.add(Door.CABRA);
        }
    }

    GameResult execute(boolean wantsChange){
        if(doors.size() > 2){
            int ind = 0;
            while(doors.get(ind) == Door.CAR || ind == selection){
                ind++;
            }
            doors.remove((ind));
            if(wantsChange){
                int newSelection = Utils.RandomInt(0,doors.size()-1);
                while(newSelection == selection){
                    newSelection = Utils.RandomInt(0,doors.size()-1);
                }
                selection = newSelection;
            }

            return GameResult.UNKNOWN;
        }

        if(doors.get(selection) == Door.CAR)
            return GameResult.WIN;
        return GameResult.LOSE;
    }

    int Simulation(int times, boolean wantsChange){
        int counter = 0;
        for(int i = 0; i < times; i++){
            Game.GameResult r = Game.GameResult.UNKNOWN;

            while (r == Game.GameResult.UNKNOWN){
                r = execute(wantsChange);
            }
            if(r == GameResult.WIN)
                counter += 1;
            init(doorsNumber);
        }
        return counter;
    }
}
