file=$1
backupDir=$2

date=$(date "+%Y-%m-%d")
fullShit="$backupDir/${file%.*}_$date.${file##*.}"

cp "$file" $fullShit
rm "$file"

echo "File removed and put in $backupDir"
