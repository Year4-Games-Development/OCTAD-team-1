**Inventory**    
1.0  
- object on player
- "inventory" command shows contents  
1.1  
- Command "use" to use an item: read todo list
- command "drop" item  

**Pickup**     
1.0  
- Location holds list of pickubables
- pickup command pick remove item from location, add to inventory

**Item**    
1.0    
- name, id  
1.1    
- item types  
1.2    
- Item interface with item types as subclasses

**NPC/Dialog**     
1.0  
- Npc exists in location
- "talk" to npc, get a response  
1.1  
- add quest to quest list
1.2
- interactable npc
- quest and rewards

**Quest System**     
1.0  
- Npc hold list of quests
-talk to npc reveals quest  
1.1  
- add quest to player list of quests
- add reward item to inventory

**Player**   
1.0
- Health / oxygen status

**Oxygen**   
1.0
- ticks down every location change
- replenish when return to ship 
1.1
- player die when oxygen equals zero

**Help Command**   
1.0  
- Shows all available commands
