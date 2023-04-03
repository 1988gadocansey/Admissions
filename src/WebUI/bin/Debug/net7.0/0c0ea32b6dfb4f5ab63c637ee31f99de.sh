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

ps 81516;
while [ $? -eq 0 ];
do
  sleep 1;
  ps 81516 > /dev/null;
done;

for child in $(list_child_processes 81837);
do
  echo killing $child;
  kill -s KILL $child;
done;
rm /Users/gadocansey/Projects/OnlineApplicationSystem/src/WebUI/bin/Debug/net7.0/0c0ea32b6dfb4f5ab63c637ee31f99de.sh;
