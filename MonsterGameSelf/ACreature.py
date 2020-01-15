import random

class Creature:
    def getName(self):
        return self.name

    def getHP(self):
        return self.hp
    def setHP(self, value):
        self.hp = value

    def __init__(self, name, hp, ap):
        self.name = name
        self.hp = hp
        self.ap = ap

        # returns whether creature died
    def Attack(self, c): # Damage is een variabele in de functie, is altijd verschillend, hoort niet bij het object.
        damage = random.randint(0, self.ap + 1)
        c.HP -= damage
        if c.HP <= 0:      
            #Console.ForegroundColor = ConsoleColor.Red;
            print(f"{self.name} attacks {c.name} and does {damage} damage. {c.name} dies.")
            #Console.ResetColor();
            return True
            
        else:   
            print("{self.name} attacks {c.name} and does {damage} damage. {c.name} now has {c.HP} HP.")
            return False
