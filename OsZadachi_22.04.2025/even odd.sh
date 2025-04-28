for i in {1..10}; do
if (( i % 2 == 0 )); then
echo "$i - Even"
elif (( i % 3 == 0 )); then
echo "$i - Odd"
else
echo "Mid? - $i"
fi
done
