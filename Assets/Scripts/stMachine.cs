//using UnityEngine;
//using System.Collections;
//
//public class stMachine : MonoBehaviour {
//
//	public enum state{
//		state_index,
//		next_state,
//		state_time,
//		state_nextnow,
//		state_next,
//		state_continue,
//		state_repeat,
//		nxt,
//
//	};
//
//
//	// Use this for initialization
//	void Start () {
//	
//
//
//
//
//	}
//	
//	// Update is called once per frame
//	void Update () {
//	
//	}
//
//
//
//
//	public void stMachine(state state_machine){
//		//Initialize
//			state_index = argument0 //default state to execute (try NOT to change directly!)
//				next_state = argument0 //next state to be executed (use THIS to change states)
//					state_time = 0 //time we've been in the current state
//
//					
//					//Return Actions (These are defined as constants already in this example)
//					state_nextnow  = 3 //execute the next state during this step
//					state_next     = 0 //execute the next state in the next step
//					state_continue = 1 //continues a state again next step
//					state_repeat   = 2 //repeat this state again THIS step
//		}
//		
//		
//		//Process State Transitions
//		state nxt;
//		nxt = stMachine(state_index)
//			
//		while (nxt == state_nextnow) { //continue going to next state during this step
//			state_index = next_state;
//			state_time = 0;
//			nxt = stMachine(state_index)
//			//if nxt = state_nextnow
//			//nxt = script_execute(state_index,arg0,arg1,arg2,arg3,arg4,arg5,arg6,arg7)
//			if (nxt == state_repeat)
//			{
//			break;
//			//exit
//		}
//
//		
//		while(nxt == state_repeat) { //repeat state but don't go to next step
//			//We'll clear the arguments if necessary
//
//			}
//			nxt = stMachine(state_index);
//			if (nxt = state_nextnow) //if state_nextnow is returned, execute the state machine
//			{
//				state_index=next_state;
//				state_time=0;
//				//We'll clear the arguments if necessary
//
//				stMachine(state_machine);
//				break;
//		}
//			state_time += 1;
//		}
//		
//		if(nxt == state_next) { //change state in the next step
//			state_index = next_state;
//			state_time = 0;
//			//We'll clear the arguments if necessary
//
//		}
//		if(nxt == state_continue) { //continue state in the next step
//			state_time += 1;
//		}
//
//	}
//}
