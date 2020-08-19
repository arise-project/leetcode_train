#!/bin/bash
MAXCOUNT=30
count=1

while [ "$count" -le $MAXCOUNT ]; do
 echo $((1 + RANDOM % 1553))
 let "count += 1"
done


