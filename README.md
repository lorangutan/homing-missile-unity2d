# homing-missile-unity2d
homing missile for Unity2D

set rb to field to the missile/follower object and set Target field as the followed object.

radar can be implemented as a circle or any shapes with a trigger collider, and the missile will start following the target if the target(set the CompareTag("Player") to CompareTag(targetTag)) collides with the radar.
sparks particle system can be optionally added to adds effect when the target collides with the radar.
