using System;

/*
ETERNAL QUEST PROGRAM - CREATIVE FEATURES & ENHANCEMENTS
========================================================

This Eternal Quest program implements all core requirements plus several creative enhancements:

CORE REQUIREMENTS MET:
1. ✓ Simple Goals: Goals that can be marked complete once
2. ✓ Eternal Goals: Goals that repeat forever and never complete
3. ✓ Checklist Goals: Goals that must be completed X times with bonus on completion
4. ✓ Display user score
5. ✓ Create new goals of any type
6. ✓ Record progress on goals
7. ✓ List goals with completion status
8. ✓ Save and load goals with persistence

DESIGN PATTERNS:
- ✓ Base Class Inheritance: Goal class with abstract methods
- ✓ Polymorphism: Each goal type overrides methods differently
- ✓ Encapsulation: Private member variables with public accessors
- ✓ Abstraction: Abstract base class defines interface

CREATIVE ENHANCEMENTS FOR 100%:
========================================================

1. LEVELING SYSTEM
   - Users earn levels as they accumulate points (500 points per level)
   - 9 different rank titles: Beginner → Eternal Rishi
   - Visual display of current level in main menu
   - Level-up notifications when advancing

2. ADDITIONAL GOAL TYPES (Beyond the 3 required)
   - Progress Goals: Track progress towards large goals (e.g., run 100 km, read 50 books)
     Shows percentage completion and doubles points on full completion
   - Bad Habit Goals: Negative goals where you lose points for bad habits
     Allows tracking of habits to break, not just habits to build

3. ENHANCED GAMIFICATION FEATURES
   - Level/rank system with creative names
   - Visual feedback with special characters and formatting
   - Achievement notifications on goal completion
   - Formatted menu displays with borders

4. IMPROVED USER EXPERIENCE
   - Better error handling with input validation
   - Clearer descriptions of goal types during creation
   - Visual distinction between different types of progress
   - Encouraging messages and feedback
   - Graceful exit message

5. CODE QUALITY
   - All abstract methods properly implemented in derived classes
   - GetDetailsString() method overridden in each goal type
   - Proper polymorphism with each goal type handling its own logic
   - Save/Load functionality supports all goal types

The program encourages long-term goal tracking while providing short-term rewards (level-ups)
to keep users motivated in their "Eternal Quest" of continuous self-improvement!
*/

class Program
{
    static void Main()
    {
        GoalManager manager = new GoalManager();
        manager.Start();
    }
}