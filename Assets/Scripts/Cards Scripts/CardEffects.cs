using UnityEngine;
using System.Collections;
using System.Reflection;

public static class CardEffects {

	public static Effect getEffect(int id, string type) {
        Effect eff = new Effect();
        if (type == "creature") {
            eff.actions.Add("Move");
            eff.actions.Add("Attack");
        }

        switch (id) {
            case 1:
                break;

            case 2:
                break;
        }

 



        return eff;
    }

}
