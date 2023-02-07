function list_child_processes () {
    local ppid=$1;
    local current_children=$(pgrep -P $ppid);
    local local_child;
    if [ $? -eq 0 ];
    then
        for current_child in $current_children
        do
          local_child=$current_child;
          list_child_processes $local_child;
          echo $local_child;
        done;
    else
      return 0;
    fi;
}

ps 26817;
while [ $? -eq 0 ];
do
  sleep 1;
  ps 26817 > /dev/null;
done;

for child in $(list_child_processes 27418);
do
  echo killing $child;
  kill -s KILL $child;
done;
rm /Users/gadocansey/Projects/TTU_ADMISSIONS/src/WebUI/bin/Debug/net7.0/c6e6d4f88ff94e1d8bb54a210d3ba317.sh;
