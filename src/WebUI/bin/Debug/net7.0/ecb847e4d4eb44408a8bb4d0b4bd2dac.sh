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

ps 23605;
while [ $? -eq 0 ];
do
  sleep 1;
  ps 23605 > /dev/null;
done;

for child in $(list_child_processes 23656);
do
  echo killing $child;
  kill -s KILL $child;
done;
rm /Users/gadocansey/Projects/OnlineApplicationSystem/src/WebUI/bin/Debug/net7.0/ecb847e4d4eb44408a8bb4d0b4bd2dac.sh;
