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

ps 15578;
while [ $? -eq 0 ];
do
  sleep 1;
  ps 15578 > /dev/null;
done;

for child in $(list_child_processes 21096);
do
  echo killing $child;
  kill -s KILL $child;
done;
rm /Users/gadocansey/Projects/TTU_ADMISSIONS/src/WebUI/bin/Debug/net7.0/a117066348b840c08b52ca11f2e4b9de.sh;
