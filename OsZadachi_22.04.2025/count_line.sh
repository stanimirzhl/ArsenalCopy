read -p "Hi cutie, need ya to drop a file:" file
if [[ -e "$file" ]]; then
echo "The file has: $(wc -l < "$file") lines"
else
echo "No existen file :("
fi
