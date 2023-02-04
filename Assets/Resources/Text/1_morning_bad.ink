VAR nurture = 0
#Narrator

What would you like to say?
+   [You've grown!]
        -> plant_silence
+   [You look cool!]
        -> plant_happy
+   [Teeth???]
        -> plant_angry
        
=== plant_silence ===
The plant looks as surprised as you.
Which is saying a lot.
Given that, it's a plant and it can't emote.
~ nurture = nurture+1
-> day2_morning_end

=== plant_happy ===
Coincidently, the plant opens its mouth and looks even more scary.
You can't help but to open your mouth in awe.
~ nurture = nurture+1
-> day2_morning_end

=== plant_angry===
The plant starts wiggling furiously.
And then suddenly it stops.
You are not quite sure what happened, since plants shouldn't be able to move like that.
Was it the wind?
~ nurture = nurture-1
-> day2_morning_end

=== day2_morning_end ===
-> END