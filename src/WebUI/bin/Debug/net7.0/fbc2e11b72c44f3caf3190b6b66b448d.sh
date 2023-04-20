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

ps 93126;
while [ $? -eq 0 ];
do
  sleep 1;
  ps 93126 > /dev/null;
done;

for child in $(list_child_processes 97053);
do
  echo killing $child;
  kill -s KILL $child;
done;
rm /Users/gadocansey/Projects/OnlineApplicationSystem/src/WebUI/bin/Debug/net7.0/fbc2e11b72c44f3caf3190b6b66b448d.sh;
