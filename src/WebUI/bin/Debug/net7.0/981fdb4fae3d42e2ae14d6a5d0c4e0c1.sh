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

ps 64787;
while [ $? -eq 0 ];
do
  sleep 1;
  ps 64787 > /dev/null;
done;

for child in $(list_child_processes 64834);
do
  echo killing $child;
  kill -s KILL $child;
done;
rm /Users/gadocansey/Projects/OnlineApplicationSystem/src/WebUI/bin/Debug/net7.0/981fdb4fae3d42e2ae14d6a5d0c4e0c1.sh;
