using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts{
    public enum SlingShotState
    {
        Idle,
        UserPulling,
        BirdFlying
    }

    public enum BirdState
    {
        BeforeThrown,
        Thrown
    }

    public enum GameState
    {
        Start,
        BirdMovingToSlingshot,
        Playing,
        Win,
        Lost
    }
}

