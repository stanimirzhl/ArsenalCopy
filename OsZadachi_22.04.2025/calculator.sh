read -p "Write number 1:" num1
read -p "Write number 2:" num2
read -p "Write the operation(+, -, /, *):" oprt

case $oprt in
+)
result=$((num1 + num2))
echo "Addition's result: $result"
;;
-)
result=$((num1 - num2))
echo "Subtraction's result: $result"
;;
\*)
result=$((num1 * num2))
echo "Multiplication's result: $result"
;;
/)
if [ "$num2" -eq 0 ]; then
echo "You can't divide by 0"
else
result=$((num1 / num2))
echo "Division's result: $result"
fi
;;
*)
echo "No such command!"
;;
esac
