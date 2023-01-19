# fairSlots
# WebApp1

## Proposal

### - Idea
A **fake**, web-based slot machine that stores specific user data (such as betting amount or frequency) and uses that to generate user specific probabilities. Another component of this application is to have a "random number generator". The goal of storing and processing user data is to improve user retention.

### - Application Name
fairSlots

### - DbSet<> Objects
1. Chances\
This is intended to store entities that calculate the chances of winning/losing and particular outcomes (for each slot).

2. History\
This object will store important information regarding the previous games of users (intended to be linked to users).

3. Game\
This object will hold information regarding the current game that is to be processed (i.e. bets, time, or state of machine).
