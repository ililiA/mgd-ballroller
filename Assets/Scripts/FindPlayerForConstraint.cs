using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class FindPlayerForConstraint : MonoBehaviour
{
    public PositionConstraint constraint;
    //public RotationConstraint rotationconstraint;
    public Transform player;
    public ConstraintSource source;
    

    void Start()
    {
        // make reference to the position constraint component
        PositionConstraint constraint =this.GetComponent<PositionConstraint>();
        //RotationConstraint rotationconstraint =this.GetComponent<RotationConstraint>();
        // find the player
        Transform player = GameObject.FindWithTag("Player").transform;
        //Quaternion rotation = GameObject.FindWithTag("Player").transform.rotation;
        //make the player an animation source
        ConstraintSource source = new ConstraintSource();
        source.sourceTransform = player;
        
        source.weight = 1;
        //add the player to postion constraint
        constraint.AddSource(source);
        //rotationconstraint.AddSource(source);

        //activate position constraint
        constraint.constraintActive = true;
        //rotationconstraint.constraintActive = true;
    }
}
