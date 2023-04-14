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

ps 27789;
while [ $? -eq 0 ];
do
  sleep 1;
  ps 27789 > /dev/null;
done;

for child in $(list_child_processes 27831);
do
  echo killing $child;
  kill -s KILL $child;
done;
rm /Users/gadocansey/Projects/OnlineApplicationSystem/src/WebUI/bin/Debug/net7.0/d2d1d28313ab4a9c9cb92f3d7278cf5a.sh;
