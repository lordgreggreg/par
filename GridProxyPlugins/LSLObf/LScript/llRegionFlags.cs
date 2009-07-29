/** 
 * @file llregionflags.h
 * @brief Flags that are sent in the statistics message region_flags field.
 *
 * $LicenseInfo:firstyear=2002&license=viewergpl$
 * 
 * Copyright (c) 2002-2009, Linden Research, Inc.
 * 
 * Second Life Viewer Source Code
 * The source code in this file ("Source Code") is provided by Linden Lab
 * to you under the terms of the GNU General Public License, version 2.0
 * ("GPL"), unless you have obtained a separate licensing agreement
 * ("Other License"), formally executed by you and Linden Lab.  Terms of
 * the GPL can be found in doc/GPL-license.txt in this distribution, or
 * online at http://secondlifegrid.net/programs/open_source/licensing/gplv2
 * 
 * There are special exceptions to the terms and conditions of the GPL as
 * it is applied to this Source Code. View the full text of the exception
 * in the file doc/FLOSS-exception.txt in this software distribution, or
 * online at
 * http://secondlifegrid.net/programs/open_source/licensing/flossexception
 * 
 * By copying, modifying or distributing this software, you acknowledge
 * that you have read and understood your obligations described above,
 * and agree to abide by those obligations.
 * 
 * ALL LINDEN LAB SOURCE CODE IS PROVIDED "AS IS." LINDEN LAB MAKES NO
 * WARRANTIES, EXPRESS, IMPLIED OR OTHERWISE, REGARDING ITS ACCURACY,
 * COMPLETENESS OR PERFORMANCE.
 * $/LicenseInfo$
 */

namespace LSLObf
{
	public partial class LSLLexer
	{

		// Can you be hurt here? Should health be on?
		const uint REGION_FLAGS_ALLOW_DAMAGE				= (1 << 0);
		
		// Can you make landmarks here?
		const uint REGION_FLAGS_ALLOW_LANDMARK			= (1 << 1);
		
		// Do we reset the home position when someone teleports away from here?
		const uint REGION_FLAGS_ALLOW_SET_HOME			= (1 << 2);
		
		// Do we reset the home position when someone teleports away from here?
		const uint REGION_FLAGS_RESET_HOME_ON_TELEPORT	= (1 << 3);
		
		// Does the sun move?
		const uint REGION_FLAGS_SUN_FIXED				= (1 << 4);
		
		// Tax free zone (no taxes on objects, land, etc.)
		const uint REGION_FLAGS_TAX_FREE					= (1 << 5);
		
		// Can't change the terrain heightfield, even on owned parcels,
		// but can plant trees and grass.
		const uint REGION_FLAGS_BLOCK_TERRAFORM			= (1 << 6);
		
		// Can't release, sell, or buy land.
		const uint REGION_FLAGS_BLOCK_LAND_RESELL		= (1 << 7);
		
		// All content wiped once per night
		const uint REGION_FLAGS_SANDBOX					= (1 << 8);
		const uint REGION_FLAGS_NULL_LAYER				= (1 << 9);
		// const uint REGION_FLAGS_SKIP_AGENT_ACTION		= (1 << 10);
		const uint REGION_FLAGS_HARD_ALLOW_LAND_TRANSFER	= (1 << 10);	// Region allows land reselling
		// const uint REGION_FLAGS_SKIP_UPDATE_INTEREST_LIST= (1 << 11);
		const uint REGION_FLAGS_HARD_ALLOW_POST_CLASSIFIED	= (1 << 11);	// Region allows posting of classified ads
		const uint REGION_FLAGS_SKIP_COLLISIONS			= (1 << 12); // Pin all non agent rigid bodies
		const uint REGION_FLAGS_SKIP_SCRIPTS				= (1 << 13);
		const uint REGION_FLAGS_SKIP_PHYSICS				= (1 << 14); // Skip all physics
		const uint REGION_FLAGS_EXTERNALLY_VISIBLE		= (1 << 15);
		//const uint REGION_FLAGS_MAINLAND_VISIBLE			= (1 << 16);
		const uint REGION_FLAGS_PUBLIC_ALLOWED			= (1 << 17);
		const uint REGION_FLAGS_BLOCK_DWELL				= (1 << 18);
		
		// Is flight allowed?
		const uint REGION_FLAGS_BLOCK_FLY				= (1 << 19);	
		
		// Is direct teleport (p2p) allowed?
		const uint REGION_FLAGS_ALLOW_DIRECT_TELEPORT	= (1 << 20);
		
		// Is there an administrative override on scripts in the region at the
		// moment. This is the similar skip scripts, except this flag is
		// presisted in the database on an estate level.
		const uint REGION_FLAGS_ESTATE_SKIP_SCRIPTS		= (1 << 21);
		
		const uint REGION_FLAGS_RESTRICT_PUSHOBJECT		= (1 << 22);
		
		const uint REGION_FLAGS_DENY_ANONYMOUS			= (1 << 23);
		// const uint REGION_FLAGS_DENY_IDENTIFIED			= (1 << 24);
		// const uint REGION_FLAGS_DENY_TRANSACTED			= (1 << 25);
		
		const uint REGION_FLAGS_ALLOW_PARCEL_CHANGES		= (1 << 26);
		
		const uint REGION_FLAGS_ABUSE_EMAIL_TO_ESTATE_OWNER = (1 << 27);
		
		const uint REGION_FLAGS_ALLOW_VOICE = (1 << 28);
		
		const uint REGION_FLAGS_BLOCK_PARCEL_SEARCH = (1 << 29);
		const uint REGION_FLAGS_DENY_AGEUNVERIFIED	= (1 << 30);
		const uint REGION_FLAGS_SKIP_MONO_SCRIPTS	= (uint)1 << 31;
		
		const uint REGION_FLAGS_DEFAULT = REGION_FLAGS_ALLOW_LANDMARK |
										 REGION_FLAGS_ALLOW_SET_HOME |
		                                 REGION_FLAGS_ALLOW_PARCEL_CHANGES |
		                                 REGION_FLAGS_ALLOW_VOICE;
		
		
		const uint REGION_FLAGS_PRELUDE_SET = REGION_FLAGS_RESET_HOME_ON_TELEPORT;
		const uint REGION_FLAGS_PRELUDE_UNSET = REGION_FLAGS_ALLOW_LANDMARK 
											   | REGION_FLAGS_ALLOW_SET_HOME;
		
		const uint REGION_FLAGS_ESTATE_MASK = REGION_FLAGS_EXTERNALLY_VISIBLE
											 | REGION_FLAGS_PUBLIC_ALLOWED	
											 | REGION_FLAGS_SUN_FIXED
											 | REGION_FLAGS_DENY_ANONYMOUS
											 | REGION_FLAGS_DENY_AGEUNVERIFIED;
		
		public bool is_prelude( uint flags )
		{
			// definition of prelude does not depend on fixed-sun
			return 0 == (flags & REGION_FLAGS_PRELUDE_UNSET)
				   && 0 != (flags & REGION_FLAGS_PRELUDE_SET);
		}
		
		public uint set_prelude_flags(uint flags)
		{
			// also set the sun-fixed flag
			return ((flags & ~REGION_FLAGS_PRELUDE_UNSET)
					| (REGION_FLAGS_PRELUDE_SET | REGION_FLAGS_SUN_FIXED));
		}
		
		public uint unset_prelude_flags(uint flags)
		{
			// also unset the fixed-sun flag
			return ((flags | REGION_FLAGS_PRELUDE_UNSET) 
					& ~(REGION_FLAGS_PRELUDE_SET | REGION_FLAGS_SUN_FIXED));
		}
		
		// estate constants. Need to match first few etries in indra.estate table.
		const uint ESTATE_ALL = 0; // will not match in db, reserved key for logic
		const uint ESTATE_MAINLAND = 1;
		const uint ESTATE_ORIENTATION = 2;
		const uint ESTATE_INTERNAL = 3;
		const uint ESTATE_SHOWCASE = 4;
		const uint ESTATE_TEEN = 5;
		const uint ESTATE_LAST_LINDEN = 5; // last linden owned/managed estate
		
		// for EstateOwnerRequest, setaccess message
		const uint ESTATE_ACCESS_ALLOWED_AGENTS	= 1 << 0;
		const uint ESTATE_ACCESS_ALLOWED_GROUPS	= 1 << 1;
		const uint ESTATE_ACCESS_BANNED_AGENTS	= 1 << 2;
		const uint ESTATE_ACCESS_MANAGERS		= 1 << 3;
		
		//maximum number of access list entries we can fit in one packet
		const int ESTATE_ACCESS_MAX_ENTRIES_PER_PACKET = 63;
		
		// for reply to "getinfo", don't need to forward to all sims in estate
		const uint ESTATE_ACCESS_SEND_TO_AGENT_ONLY = 1 << 4;
		
		const uint ESTATE_ACCESS_ALL = ESTATE_ACCESS_ALLOWED_AGENTS
									  | ESTATE_ACCESS_ALLOWED_GROUPS
									  | ESTATE_ACCESS_BANNED_AGENTS
									  | ESTATE_ACCESS_MANAGERS;
		
		// for EstateOwnerRequest, estateaccessdelta message
		const uint ESTATE_ACCESS_APPLY_TO_ALL_ESTATES		= 1 << 0;
		const uint ESTATE_ACCESS_APPLY_TO_MANAGED_ESTATES	= 1 << 1;
		
		const uint ESTATE_ACCESS_ALLOWED_AGENT_ADD			= 1 << 2;
		const uint ESTATE_ACCESS_ALLOWED_AGENT_REMOVE		= 1 << 3;
		const uint ESTATE_ACCESS_ALLOWED_GROUP_ADD			= 1 << 4;
		const uint ESTATE_ACCESS_ALLOWED_GROUP_REMOVE		= 1 << 5;
		const uint ESTATE_ACCESS_BANNED_AGENT_ADD			= 1 << 6;
		const uint ESTATE_ACCESS_BANNED_AGENT_REMOVE			= 1 << 7;
		const uint ESTATE_ACCESS_MANAGER_ADD					= 1 << 8;
		const uint ESTATE_ACCESS_MANAGER_REMOVE				= 1 << 9;
		const uint ESTATE_ACCESS_NO_REPLY                                  = 1 << 10;
		
		const int ESTATE_MAX_MANAGERS = 10;
		const int ESTATE_MAX_ACCESS_IDS = 500;	// max for access, banned
		const int ESTATE_MAX_GROUP_IDS = (int) ESTATE_ACCESS_MAX_ENTRIES_PER_PACKET;
		
		// 'Sim Wide Delete' flags
		const uint SWD_OTHERS_LAND_ONLY		= (1 << 0);
		const uint SWD_ALWAYS_RETURN_OBJECTS = (1 << 1);
		const uint SWD_SCRIPTED_ONLY			= (1 << 2);

	}
}