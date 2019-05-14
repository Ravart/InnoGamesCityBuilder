# Architecture

The chosen architecture is a new ECS system created by Unity called Dots, which highly focus performance (which it achieves) and is probably going to be Unitys next big thing. It enforces a highly structured code by separating game data (components) from execution (systems/jobs), though it's still in preview, meaning Unity changes code (quite drastically), few tutorials (most of them outdated) and personally I wish to have achieved more of the goals in this eight hours, since a lot of time was spent figuring out this new ECS system.

My reason to use ECS had a few different reasons, the game itself seemed perfectly suitable for ECS, its performance boost compared to Unitys native component system is no joke (even on mobile devices) and showing that I'm capable to adept new technology I have never used (though completed fewer features than hoped and would have using the vanilla way). 


## Data Storage
I created a ScriptableObject called "BuildingAsset", which allows to instatiate linked prefab (which turns on first update call immediately into an entity). Any game logic is directly placed on the prefabs ( in ECS components declares which kind of jobs have to be executed on entities).

Preferably I would have let every ScriptableObject itself handle the adding of entities with required components, though doing that with prefabs of multiple gameObject is a bigger process.

Since every entity can only render one mesh, a prefab with two gameObjects requires two entities (chained together by components). Doing this chaining process by code requires a better understanding and more time. Conventionally I used the ConvertToUnity Monobehaviour, which is fine and done in the examples, though not the fastest it could be (everything done outside the ECS can be considered a bottleneck).

##Functionality
Any logic is added to entities by adding components, therefore by adding or removing components we add or remove functionality. A simple example is the prefab Bench1x1 and Building3x3, both have the ConstructProxy component (Proxy classes convert Monobehaviour components to ECS components), therefore their entities have the ConstructComponent. The ConstructSysJob is executed on every entity with ConstructComponent, in this example it meshed is raised from the ground in a timeframe of 10 seconds, simulating getting build.

Since Building3x3 produce resources, the ProduceProxy component was, resulting it to add every 10 seconds specific amount of resources to the player entity.

##Jobs
ECS is fast because of the JobSystem, allowing processing everything on multiple threads. It works great and adding new functionality is done by adding a new job and a new component, further execution of different jobs can be queued (a feature missing with native Update). 

Mostly ECS is simple, until you try to access and manipulate data from an entity not iterated by the job. 
Probably possibly, though I haven't figured out the right way to do it yet. In my solution (ProductionSysJob and PayoutSysJob) I collect required data before executing the job, which means this collecting part of code always runs on the mainthread and is "normally slow". Since multi threading is use, it make sense to disallow casual overwriting values in other entities, though it's definitely possible.


# Test assessment for Unity candidates

*Test project for applicants:*
Requires Unity 2018.3.0f2 or higher (in older ones some models can be broken)

**Goal:**
Implement a simple city builder where you can place and move buildings and produce resources from these buildings.

* Please, don't spend more than 6-8 hours on it.
* Please, concentrate on data structures, separation of concerns and architecture  of the game. UX, usability and prettines are not important at all.
* If you didn't implement all features - it's fine, feature's list is pretty big. Main goal for us is to see an architecture behind.
* In the end, please, provide a description explaning why you did this task the way you did (why did you choose certain architecture, UI management, data structures, etc) and what would you do differently if you would have more time. 

**Desired set of features:**

The game should have two main modes:
* **Regular mode:** in which player can select a building by clicking on it and see a building name on top of it and current production progress (or can start a new production if no production is running)
* **Build mode:** the player can place a new building or move an existing building 
when player presses 'build mode' he should see a simple list with building's names and their prices where he can choose a new building to place.
Or the player can either select and move an existing building on the grid.

* Buildings should not be placeable on cells occupied by other buildings
* Placing a building cost resources
* When building is placed it should go through construction phase first (simple progressbar on top of the building) for 10 seconds before it can produce anything.

**Building types**

3 Types of production buildings:
* 'Residence' - a building which produces automatically 100 gold every 10 seconds. After production is finished, the next one starts automatically. 
Placing a building cost 100 gold
* 'Wood production building' - a building which player first have to select and press 'start production' (just a simple button which appears on top of the building when we select it) and after it should start producing 50 wood in 10 seconds.
Placing a building cost 150 gold
* 'Steel production building' - same as wood production but produces steel instead. Produces 50 steel in 10 seconds.
Placing a building cost 150 gold and 100 wood

* Player should also be able to select a building in the regular mode by clicking on it and see a simple progressbar of current production progress. 

*OPTIONAL*: 2 Types of decoration buildings:
* 'Bench' - a simple bench decoration which player can place.
Placing cost 150 gold and 50 steel
* 'Tree' - a simple decoration which player can place.  
Placing cost 50 gold and 200 wood


*Included Resources:*
* Set of prefabs of buildings with different grid sizes
* Simple grid shader
* Test scene with a grid and a few prefabs placed.
* Some base UI
