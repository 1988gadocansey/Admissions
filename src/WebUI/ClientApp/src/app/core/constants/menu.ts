import { MenuItem } from '../models/menu.model';

export class Menu {
  public static pages: MenuItem[] = [
    {
      group: 'Home',
      separator: false,
      items: [
        {
          icon: 'assets/icons/outline/chart-pie.svg',
          label: 'My Profile',
          route: '/dashboard',
          children: [
            { label: 'Home', route: '/welcome/live' },
            { label: 'Upload Passport Photo', route: '/upload/passport' },
            { label: 'Change Form', route: '/changes/form' },
            /*  { label: 'Report Issue', route: '/issues/report' }, */
            { label: 'Announcements', route: '/announcements/index' },

          ],
        },

      ],
    },
    {
      group: 'Forms',
      separator: false,
      items: [
        {
          icon: 'assets/icons/outline/chart-pie.svg',
          label: 'Steps',
          route: '/academics',
          children: [
            { label: 'Biodata', route: '/stepone/biodata' },
            { label: 'Location Information', route: '/steptwo/address' },
            { label: 'Programme & Educational Information', route: '/stepthree/academics', },
            { label: 'Upload of Result', route: '/stepfour/results', },
            /*  { label: 'Research Information', route: '/download', },
             { label: 'List of Referees', route: '/download', },
             { label: 'Supporting Documents', route: '/download', }, */
            // { label: 'Application Summary', route: '/download', },
            { label: 'Proof of Application', route: '/proof/preview', },
            // { label: 'Application Status', route: '/download', },
          ],
        },

      ],
    },
    /* {
      group: 'Academics',
      separator: false,
      items: [
        {
          icon: 'assets/icons/outline/download.svg',
          label: 'Option Change',
          route: '/download',
        },
        {
          icon: 'assets/icons/outline/download.svg',
          label: 'Registration',
          route: '/academics/registration',
        },
        {
          icon: 'assets/icons/outline/download.svg',
          label: 'Statement of Result',
          route: '/download',
        },
        {
          icon: 'assets/icons/outline/gift.svg',
          label: 'Official Documents',
          route: '/gift',
        },
        {
          icon: 'assets/icons/outline/gift.svg',
          label: 'Clarence',
          route: '/gift',
        },
        {
          icon: 'assets/icons/outline/gift.svg',
          label: 'Virtual Classroom',
          route: '/gift',
        },

      ],
    }, */
    {
      group: 'Accomodation',
      separator: false,
      items: [
        {
          icon: 'assets/icons/outline/cog.svg',
          label: 'Book Room',
          route: '/accomodation/book',
        }

      ],
    },

    {
      group: 'Finance',
      separator: false,
      items: [
        {
          icon: 'assets/icons/outline/cog.svg',
          label: 'Bills',
          route: '/settings',
        },
        {
          icon: 'assets/icons/outline/cog.svg',
          label: 'Pay Fees',
          route: '/settings',
        },
        {
          icon: 'assets/icons/outline/bell.svg',
          label: 'Payments',
          route: '/gift',
        },

      ],
    },
  ];
}
