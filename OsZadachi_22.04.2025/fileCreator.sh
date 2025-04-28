read -p "How many files you want to create?" number

for i in $(seq 1 $number); do
fileName="file$i.txt"
touch "$fileName"
echo "$fileName was created"
done
