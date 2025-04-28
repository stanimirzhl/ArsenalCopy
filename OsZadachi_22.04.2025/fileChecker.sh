file=$1

if [[ -e "$file" ]]; then
echo "File with name ${file%.*} exists in the current directory"
else
echo "File does not exist"
fi
