#!/bin/bash

number=1

until (( $number > 10 )) do
echo "$number"
number=$(( number+1 ))
done

echo

for i in {1..15..5}
do
echo $i
done

args=("$@")

echo ${args[@]}
