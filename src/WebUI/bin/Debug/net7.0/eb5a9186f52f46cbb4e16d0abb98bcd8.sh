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

ps 39365;
while [ $? -eq 0 ];
do
  sleep 1;
  ps 39365 > /dev/null;
done;

for child in $(list_child_processes 39594);
do
  echo killing $child;
  kill -s KILL $child;
done;
rm /Users/gadocansey/Projects/OnlineApplicationSystem/src/WebUI/bin/Debug/net7.0/eb5a9186f52f46cbb4e16d0abb98bcd8.sh;
