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

ps 51026;
while [ $? -eq 0 ];
do
  sleep 1;
  ps 51026 > /dev/null;
done;

for child in $(list_child_processes 51141);
do
  echo killing $child;
  kill -s KILL $child;
done;
rm /Users/gadocansey/Projects/OnlineApplicationSystem/src/WebUI/bin/Debug/net7.0/f6c4cb7241394a7b96b3adbfa3daa181.sh;
